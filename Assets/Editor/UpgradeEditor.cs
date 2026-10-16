using System;
using System.IO;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class UpgradeEditor : EditorWindow
{
    private const string BaseResourcesPath = "Assets/Scripts/ScriptableObject/Upgrades";

    TextField upgradeNameField;
    EnumField categoryField;
    EnumField rarityField;
    FloatField incrementField;
    TextField descriptionField;
    ObjectField iconField;

    // Specific upgrade type fields for each subclass
    EnumField meleeTypeField;
    EnumField rangeTypeField;
    EnumField playerTypeField;
    VisualElement typeFieldsContainer;

    Label statusLabel;

    [MenuItem("BulletHell/Upgrade Creator")]
    static void Open()
    {
        var window = GetWindow<UpgradeEditor>();
        window.titleContent = new GUIContent("Upgrade Creator");
        window.minSize = new Vector2(350, 420);
    }

    void CreateGUI()
    {
        var root = rootVisualElement;
        root.style.paddingLeft = root.style.paddingRight = 12;
        root.style.paddingTop = 10;

        root.Add(new Label("Create a new Upgrade Asset")
        {
            style = { unityFontStyleAndWeight = FontStyle.Bold, fontSize = 14, marginBottom = 8 }
        });

        upgradeNameField = new TextField("Asset Name");
        categoryField = new EnumField("Category", UpgradeData.UpgradeCategory.Melee);
        rarityField = new EnumField("Rarity", UpgradeData.RarityType.Common);
        incrementField = new FloatField("Upgrade Increment");

        descriptionField = new TextField("Description") { multiline = true };
        descriptionField.style.minHeight = 60;

        iconField = new ObjectField("Upgrade Icon")
        {
            objectType = typeof(Sprite)
        };

        // Initialize specific enum fields matching each subclass's TypeOfUpgrade enum
        meleeTypeField = new EnumField("Melee Upgrade Type", MeleeUpgradeData.TypeOfUpgrade.Damage);
        rangeTypeField = new EnumField("Range Upgrade Type", RangeUpgradeData.TypeOfUpgrade.FireRate);
        playerTypeField = new EnumField("Player Upgrade Type", PlayerUpgradeData.TypeOfUpgrade.Health);

        // Container to toggle visibility based on selected category
        typeFieldsContainer = new VisualElement();
        typeFieldsContainer.Add(meleeTypeField);
        typeFieldsContainer.Add(rangeTypeField);
        typeFieldsContainer.Add(playerTypeField);

        // Listen for category changes to swap visible upgrade types
        categoryField.RegisterValueChangedCallback(evt =>
            UpdateTypeFieldVisibility((UpgradeData.UpgradeCategory)evt.newValue));

        var createButton = new Button(CreateAsset) { text = "Create Upgrade" };
        createButton.style.marginTop = 12;
        createButton.style.height = 30;

        statusLabel = new Label();
        statusLabel.style.marginTop = 6;
        statusLabel.style.whiteSpace = WhiteSpace.Normal;

        // Add elements to root
        root.Add(upgradeNameField);
        root.Add(categoryField);
        root.Add(rarityField);
        root.Add(incrementField);
        root.Add(typeFieldsContainer);
        root.Add(descriptionField);
        root.Add(iconField);
        root.Add(createButton);
        root.Add(statusLabel);

        // Set initial state
        UpdateTypeFieldVisibility((UpgradeData.UpgradeCategory)categoryField.value);
    }

    void UpdateTypeFieldVisibility(UpgradeData.UpgradeCategory category)
    {
        meleeTypeField.style.display = (category == UpgradeData.UpgradeCategory.Melee) ? DisplayStyle.Flex : DisplayStyle.None;
        rangeTypeField.style.display = (category == UpgradeData.UpgradeCategory.Range) ? DisplayStyle.Flex : DisplayStyle.None;
        playerTypeField.style.display = (category == UpgradeData.UpgradeCategory.Player) ? DisplayStyle.Flex : DisplayStyle.None;
    }

    void CreateAsset()
    {
        if (string.IsNullOrWhiteSpace(upgradeNameField.value))
        {
            statusLabel.text = "Asset name is required.";
            return;
        }

        var category = (UpgradeData.UpgradeCategory)categoryField.value;
        UpgradeData upgradeAsset = null;

        // Instantiate the proper subclass based on the selected category
        switch (category)
        {
            case UpgradeData.UpgradeCategory.Melee:
                upgradeAsset = ScriptableObject.CreateInstance<MeleeUpgradeData>();
                break;
            case UpgradeData.UpgradeCategory.Range:
                upgradeAsset = ScriptableObject.CreateInstance<RangeUpgradeData>();
                break;
            case UpgradeData.UpgradeCategory.Player:
                upgradeAsset = ScriptableObject.CreateInstance<PlayerUpgradeData>();
                break;
        }

        if (upgradeAsset == null)
        {
            statusLabel.text = "Failed to create upgrade instance.";
            return;
        }

        var so = new SerializedObject(upgradeAsset);

        // Helper to target auto-property backing fields generated by [field: SerializeField]
        void Set(string name, Action<SerializedProperty> assign)
        {
            var prop = so.FindProperty($"<{name}>k__BackingField");
            if (prop != null) assign(prop);
        }

        // Set base properties
        Set("Rarity", p => p.enumValueIndex = Convert.ToInt32(rarityField.value));
        Set("UpgradeIncrement", p => p.floatValue = incrementField.value);
        Set("Category", p => p.enumValueIndex = Convert.ToInt32(categoryField.value));
        Set("UpgradeDescription", p => p.stringValue = descriptionField.value);
        Set("UpgradeIcon", p => p.objectReferenceValue = iconField.value);

        // Set subclass-specific UpgradeType enum value
        switch (category)
        {
            case UpgradeData.UpgradeCategory.Melee:
                Set("UpgradeType", p => p.enumValueIndex = Convert.ToInt32(meleeTypeField.value));
                break;
            case UpgradeData.UpgradeCategory.Range:
                Set("UpgradeType", p => p.enumValueIndex = Convert.ToInt32(rangeTypeField.value));
                break;
            case UpgradeData.UpgradeCategory.Player:
                Set("UpgradeType", p => p.enumValueIndex = Convert.ToInt32(playerTypeField.value));
                break;
        }

        so.ApplyModifiedPropertiesWithoutUndo();

        // Route dynamically to subfolders: e.g., Assets/Scripts/ScriptableObject/Upgrades/Melee/
        string targetFolderPath = $"{BaseResourcesPath}/{category}";
        Directory.CreateDirectory(targetFolderPath);

        string safeName = string.Join("_", upgradeNameField.value.Split(Path.GetInvalidFileNameChars()));
        string path = AssetDatabase.GenerateUniqueAssetPath($"{targetFolderPath}/{safeName}.asset");

        AssetDatabase.CreateAsset(upgradeAsset, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        EditorGUIUtility.PingObject(upgradeAsset);
        Selection.activeObject = upgradeAsset;
        statusLabel.text = $"Created {path}";
    }
}
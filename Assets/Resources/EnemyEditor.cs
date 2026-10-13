using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static EnemyData;

public class EnemyEditor : EditorWindow
{
    const string ResourcesPath = "Assets/Scripts/ScriptableObject/Characters/Enemies";

    TextField tagField;
    TextField descriptionField;
    [Range(0f,5f)]
    FloatField attackCoolDownField;
    [Range(1f, 10f)]
    FloatField movementSpeedField;
    [Range(0.1f, 1000f)]
    FloatField baseDamageField;
    [Range(1, 100000)]
    IntegerField maxHpField;
    [Range(50, 10000)]
    IntegerField scoreValueField;
    Toggle meleeResistantField;
    Toggle rangeResistantField;
    EnumField enemyDamageTypeField;
    EnumField enemyTypeField;
    Label statusLabel;


[MenuItem("BulletHell/Enemy Creator")]
    static void Open()
    {
        var window = GetWindow<EnemyEditor>();
        window.titleContent = new GUIContent("Enemy Creator");
        window.minSize = new Vector2(320, 220);
    }

    void CreateGUI()
    {
        var root = rootVisualElement;
        root.style.paddingLeft = root.style.paddingRight = 8;
        root.style.paddingTop = 8;

        root.Add(new Label("Create a new Enemy asset")
        {
            style = { unityFontStyleAndWeight = FontStyle.Bold, marginBottom = 6 }
        });

        tagField = new TextField("Enemy Name");
        descriptionField = new TextField("Description") { multiline = true };
        descriptionField.style.minHeight = 60;

        attackCoolDownField = new FloatField("Attack Cooldown");
        movementSpeedField = new FloatField("Movement Speed");
        baseDamageField = new FloatField("Base Damage");

        scoreValueField = new IntegerField("Score Value");
        maxHpField = new IntegerField("MaxHp");

        meleeResistantField = new Toggle("Melee resistant");
        rangeResistantField = new Toggle("Range resistant");

        enemyDamageTypeField = new EnumField("Enemy Damage Type", DamageType.Ranged);
        enemyTypeField = new EnumField("Enemy Damage Type", EnemyType.Grounded);


        var createButton = new Button(CreateAsset) { text = "Create" };
        createButton.style.marginTop = 8;

        statusLabel = new Label();
        statusLabel.style.marginTop = 6;
        statusLabel.style.whiteSpace = WhiteSpace.Normal;

        root.Add(tagField);
        root.Add(enemyTypeField);
        root.Add(enemyDamageTypeField);
        root.Add(descriptionField);
        root.Add(maxHpField);
        root.Add(statusLabel);
        root.Add(attackCoolDownField);
        root.Add(movementSpeedField);
        root.Add(baseDamageField);
        root.Add(scoreValueField);
        root.Add(meleeResistantField);
        root.Add(rangeResistantField);
        root.Add(createButton);
    }

    void CreateAsset()
    {

        var enemy = ScriptableObject.CreateInstance<EnemyData>();
        var so = new SerializedObject(enemy);

        void Set(string name, Action<SerializedProperty> assign) =>
            assign(so.FindProperty($"<{name}>k__BackingField"));

        Set("Tag", p => p.stringValue = tagField.value);
        Set("EnemyDescription", p => p.stringValue = descriptionField.value);
        Set("MaxHP", p => p.floatValue = maxHpField.value);
        Set("AttackCooldown", p => p.floatValue = attackCoolDownField.value);
        Set("MovementSpeed", p => p.floatValue = movementSpeedField.value);
        Set("BaseDamage", p => p.floatValue = baseDamageField.value);
        Set("ScoreValue", p => p.intValue = scoreValueField.value);
        Set("MeleeResist", p => p.boolValue = meleeResistantField.value);
        Set("RangeResist", p => p.boolValue = rangeResistantField.value);
        Set("EnemyDamageType", p => p.enumValueIndex = Convert.ToInt32(enemyDamageTypeField.value));
        Set("Type", p => p.enumValueIndex = Convert.ToInt32(enemyTypeField.value));

        so.ApplyModifiedPropertiesWithoutUndo();

        if (string.IsNullOrWhiteSpace(tagField.value))
        {
            statusLabel.text = "Item name is required.";
            return;
        }

        Directory.CreateDirectory(ResourcesPath);

        string safeName = string.Join("_", tagField.value.Split(Path.GetInvalidFileNameChars()));
        string path = AssetDatabase.GenerateUniqueAssetPath($"{ResourcesPath}/{safeName}.asset");

        AssetDatabase.CreateAsset(enemy, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        EditorGUIUtility.PingObject(enemy);
        Selection.activeObject = enemy;
        statusLabel.text = $"Created {path}";
    }
}
using UnityEngine;

public class UpgradeData : ScriptableObject
{
    public enum RarityType
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
    [field: SerializeField] public RarityType Rarity { get; private set; }
    [field: SerializeField] public float UpgradeIncrement { get; private set; }

    public virtual string GetUpgradeTypeName() => string.Empty;
}

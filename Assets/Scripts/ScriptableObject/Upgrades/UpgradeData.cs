using System;
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

    public enum UpgradeCategory
    {
        Melee,
        Range,
        Player
    }
    [field: SerializeField] public RarityType Rarity { get; private set; }
    [field: SerializeField] public float UpgradeIncrement { get; private set; }
    [field: SerializeField] public UpgradeCategory Category { get; private set; }
    [field: SerializeField] public string UpgradeDescription { get; private set; }

    public virtual string GetUpgradeTypeName() => string.Empty;
    public virtual void ApplyUpgrade(Stats stats) { }
}

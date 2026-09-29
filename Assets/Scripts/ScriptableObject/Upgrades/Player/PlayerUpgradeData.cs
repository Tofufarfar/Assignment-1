using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Player")]
public class PlayerUpgradeData : UpgradeData
{
    public enum TypeOfUpgrade
    {
        Movement,
        Health,
        XPGain,
        Vacuum,
        Armor
    }
    [field: SerializeField] public TypeOfUpgrade UpgradeType { get; private set; }
    public override string GetUpgradeTypeName() => UpgradeType.ToString();
}

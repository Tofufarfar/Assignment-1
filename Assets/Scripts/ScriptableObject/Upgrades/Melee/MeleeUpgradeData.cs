using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Melee")]
public class MeleeUpgradeData : UpgradeData
{
    public enum TypeOfUpgrade
    {
        Size,
        Swing,
        Arc,
        LifeLeech
    }
    [field: SerializeField] public TypeOfUpgrade UpgradeType { get; private set; }

    public override string GetUpgradeTypeName() => UpgradeType.ToString();
}

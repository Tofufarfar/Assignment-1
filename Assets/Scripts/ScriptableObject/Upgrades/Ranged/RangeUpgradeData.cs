using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Ranged")]
public class RangeUpgradeData : UpgradeData
{
    public enum TypeOfUpgrade
    {
        ProjectileBlastRadius,
        ProjectileRange,
        ProjectileSpeed,
        FireRate,
        MagazineSize,
        ReloadTime
    }
    [field: SerializeField] public TypeOfUpgrade UpgradeType { get; private set; }

    public override string GetUpgradeTypeName() => UpgradeType.ToString();
}

using System;
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
    public override void ApplyUpgrade(Stats stats)
    {
        if ( stats is RangeStats rangedStats)
        {
            switch (UpgradeType)
            {
                case TypeOfUpgrade.ProjectileBlastRadius:
                    rangedStats.IncreaseProjectileBlastRadius(UpgradeIncrement);
                    break;
                case TypeOfUpgrade.ProjectileRange:
                    rangedStats.IncreaseProjectileRange(UpgradeIncrement);
                    break;
                case TypeOfUpgrade.ProjectileSpeed:
                    rangedStats.IncreaseProjectileSpeed(UpgradeIncrement);
                    break;
                case TypeOfUpgrade.FireRate:
                    rangedStats.IncreaseProjectileFireRate(UpgradeIncrement);
                    break;
                case TypeOfUpgrade.MagazineSize:
                    rangedStats.IncreaseMagazineSize((int)UpgradeIncrement);
                    break;
                case TypeOfUpgrade.ReloadTime:
                    rangedStats.IncreaseReloadSpeed(UpgradeIncrement);
                    break;
            }
        }
    }
}

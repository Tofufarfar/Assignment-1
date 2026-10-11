using System;
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

    public override Enum GetUpgradeType() => UpgradeType;
    public override string GetUpgradeTypeName() => UpgradeType.ToString();

    public override void ApplyUpgrade(Stats stats)
    {
        if(stats is PlayerStats playerStats)
        {
            switch (UpgradeType)
            {
                case TypeOfUpgrade.Movement:
                    playerStats.IncreaseMovementSpeed(UpgradeIncrement);
                    break;
                case TypeOfUpgrade.Health:
                    playerStats.IncreaseMaxHealth((int)UpgradeIncrement);
                    break;
                case TypeOfUpgrade.XPGain:
                    playerStats.IncreaseXPGain((int)UpgradeIncrement);
                    break;
                case TypeOfUpgrade.Vacuum:
                    playerStats.IncreaseVacuumEffect((int)UpgradeIncrement);
                    break;
                case TypeOfUpgrade.Armor:
                    playerStats.IncreaseArmor((int)UpgradeIncrement);
                    break;
            }
        }
        
    }
}

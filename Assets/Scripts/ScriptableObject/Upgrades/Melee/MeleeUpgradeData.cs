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
    public override void ApplyUpgrade(Stats stats)
    {
        if (stats is MeleeStats meleeStats)
        {
            switch (UpgradeType)
            {
                case TypeOfUpgrade.Size:
                    meleeStats.IncreaseSize((int)UpgradeIncrement);
                    break;
                case TypeOfUpgrade.Swing:
                    meleeStats.IncreaseSwingSpeed((int)UpgradeIncrement);
                    break;
                case TypeOfUpgrade.Arc:
                    meleeStats.IncreaseArc((int)UpgradeIncrement);
                    break;
                //case TypeOfUpgrade.LifeLeech:
                //    meleeStats.IncreaseLifeLeech(UpgradeIncrement);
                //    break;
            }
        }
    }
}

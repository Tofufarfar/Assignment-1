using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateUpgrade : MonoBehaviour
{
    [SerializeField] MeleeUpgradeData[] _meleeUpgradePool;
    [SerializeField] PlayerUpgradeData[] _playerUpgradePool;
    [SerializeField] RangeUpgradeData[] _rangeUpgradePool;

    void Start()
    {
        GenerateAndPickOption();
    }

    UpgradeData.RarityType RarityRoll()
    {
        float _rarityRoll = Random.value;

        if (_rarityRoll <= 0.5)
        {
            return UpgradeData.RarityType.Uncommon;
        }
        if (_rarityRoll <= 0.80)
        {
            return UpgradeData.RarityType.Common;
        }
        if (_rarityRoll <= 0.95)
        {
            return UpgradeData.RarityType.Rare;
        }
        if (_rarityRoll < 0.99)
        {
            return UpgradeData.RarityType.Epic;
        }
 
            return UpgradeData.RarityType.Legendary;
    }

    UpgradeData PickFromPool(UpgradeData[] pool, UpgradeData.RarityType rarity)
    {
        var matches = pool.Where(u => u.Rarity == rarity).ToArray();
        if (matches.Length == 0) matches = pool;
        return matches[Random.Range(0, matches.Length)];
    }

    public UpgradeData[] GenerateAndPickOption()
    {
        UpgradeData[][] pools = { _meleeUpgradePool, _rangeUpgradePool, _playerUpgradePool };
        var options = new List<UpgradeData>(3);

        foreach (var pool in pools)
        {
            UpgradeData option = PickFromPool(pool, RarityRoll());
            options.Add(option);
        }

        return options.ToArray();
    }
}

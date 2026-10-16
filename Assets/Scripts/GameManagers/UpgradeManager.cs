using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    readonly Dictionary<UpgradeData.UpgradeCategory, Stats> _map = new();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Register(UpgradeData.UpgradeCategory category, Stats stats) => _map[category] = stats;

    public Stats GetStatsForCategory(UpgradeData.UpgradeCategory category)
    {
        _map.TryGetValue(category, out var stats);
        return stats;
    }
}

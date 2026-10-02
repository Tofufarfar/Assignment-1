using System;
using UnityEngine;

public class PlayerStats : Stats
{
    [SerializeField] PlayerClassData _playerUpgradeData;

    public int _maxHealth { get; private set; }
    public int _percentageXPGain { get; private set; }
    public int _armor { get; private set; }
    public int _vacuumEffect { get; private set; }
    public float _movementSpeed { get; private set; }
    
    public event Action OnPlayerStatsChanged;

    void Awake()
    {
        _maxHealth = _playerUpgradeData.MaxHealth;
        _percentageXPGain = _playerUpgradeData.XPGain;
        _movementSpeed = _playerUpgradeData.MoveSpeed;
        _vacuumEffect = _playerUpgradeData.Vacuum;
        _armor = _playerUpgradeData.Armor;
    }

    void Start()
    {
        if (UpgradeManager.Instance == null)
        {
            Debug.LogError("UpgradeManager instance is null. Make sure the UpgradeManager is initialized before accessing it.");
        }
        else
        {
            UpgradeManager.Instance.Register(UpgradeData.UpgradeCategory.Player, this);
        }
    }

    public void IncreaseMaxHealth(int amount) => _maxHealth = ApplyIntStat(_maxHealth, amount, 1, 9999);
    public void IncreaseXPGain(int amount) => _percentageXPGain = ApplyIntStat(_percentageXPGain, amount, 0,1000);
    public void IncreaseArmor(int amount) => _armor = ApplyIntStat(_armor, amount, 0, 1000);
    public void IncreaseVacuumEffect(int amount) => _vacuumEffect = ApplyIntStat(_vacuumEffect, amount, 0, 100);
    public void IncreaseMovementSpeed(float amount) => _movementSpeed = ApplyFloatStat(_movementSpeed, amount, 0, 100);
   

    private int ApplyIntStat(int stat, int increaseAmount, int min = int.MinValue, int max = int.MaxValue)
    {
        stat = Mathf.Clamp(stat + increaseAmount, min, max);
        OnPlayerStatsChanged?.Invoke();
        return stat;
    }
    private float ApplyFloatStat(float stat, float increaseAmount, float min = float.MinValue, float max = float.MaxValue)
    {
        stat = Mathf.Clamp(stat + increaseAmount, min, max);
        OnPlayerStatsChanged?.Invoke();
        return stat;
    }
}

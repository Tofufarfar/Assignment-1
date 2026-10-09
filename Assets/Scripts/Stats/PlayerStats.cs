using System;
using UnityEngine;

public class PlayerStats : Stats
{
    [SerializeField] PlayerClassData _playerUpgradeData;

    [field: SerializeField] public float MaxMovementSpeed { get; private set; } = 15f;
    [field: SerializeField] public int MaxVacuumEffect { get; private set; } = 100;
    public float MaxHealth { get; private set; }
    public int PercentageXPGain { get; private set; }
    public int Armor { get; private set; }
    public int VacuumEffect { get; private set; }
    public float MovementSpeed { get; private set; }

    public event Action OnPlayerStatsChanged;

    void Awake()
    {
        MaxHealth = _playerUpgradeData.MaxHP;
        PercentageXPGain = _playerUpgradeData.XPGain;
        MovementSpeed = _playerUpgradeData.MovementSpeed;
        VacuumEffect = _playerUpgradeData.Vacuum;
        Armor = _playerUpgradeData.Armor;
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

    public void IncreaseMaxHealth(float amount) 
    {
        MaxHealth = ApplyFloatStat(MaxHealth, amount, 1, 9999);
        OnPlayerStatsChanged?.Invoke();
    }
    public void IncreaseXPGain(int amount)
    {
        PercentageXPGain = ApplyIntStat(PercentageXPGain, amount, 0, 1000);
        OnPlayerStatsChanged?.Invoke();
    }
    public void IncreaseArmor(int amount) 
    {
        Armor = ApplyIntStat(Armor, amount, 0, 1000);
        OnPlayerStatsChanged?.Invoke();
    }
    public void IncreaseVacuumEffect(int amount)
    {
        VacuumEffect = ApplyIntStat(VacuumEffect, amount, 0, MaxVacuumEffect);
        OnPlayerStatsChanged?.Invoke();
    }
    public void IncreaseMovementSpeed(float amount)
    {
        MovementSpeed = ApplyFloatStat(MovementSpeed, amount, 0, MaxMovementSpeed);
        OnPlayerStatsChanged?.Invoke();
    }



    private int ApplyIntStat(int stat, int increaseAmount, int min = int.MinValue, int max = int.MaxValue)
    {
        stat = Mathf.Clamp(stat + increaseAmount, min, max);
        return stat;
    }
    private float ApplyFloatStat(float stat, float increaseAmount, float min = float.MinValue, float max = float.MaxValue)
    {
        stat = Mathf.Clamp(stat + increaseAmount, min, max);
        return stat;
    }
}

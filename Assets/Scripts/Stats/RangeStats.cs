using System;
using UnityEngine;

public class RangeStats : Stats
{
    [SerializeField] RangedWeaponData _rangedWeaponData;
    public float Damage { get; private set; }
    public float ProjectileBlastRadius { get; private set; }
    public float ProjectileRange { get; private set; }
    public float ProjectileSpeed { get; private set; }
    public float ProjectileFireRate { get; private set; }
    public int MagazineSize { get; private set; }
    public float ReloadSpeed { get; private set; }

    public event Action OnRangeStatsChanged;


    void Awake()
    {
        ProjectileBlastRadius = _rangedWeaponData.ProjectileBlastRadius;
        ProjectileRange = _rangedWeaponData.ProjectileRange;
        ProjectileSpeed = _rangedWeaponData.ProjectileSpeed;
        ProjectileFireRate = _rangedWeaponData.FireRate;
        MagazineSize = _rangedWeaponData.MagazineSize;
        ReloadSpeed = _rangedWeaponData.ReloadSpeed;
    }

    void Start()
    {
        if(UpgradeManager.Instance == null)
        {
            Debug.LogError("UpgradeManager instance is null. Make sure the UpgradeManager is initialized before accessing it.");
        }
        else
        {
            UpgradeManager.Instance.Register(UpgradeData.UpgradeCategory.Range, this);
        }
    }

    public void IncreaseDamage(float amount)
    {
        Damage = ApplyFloatStat(Damage, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }
    public void IncreaseProjectileBlastRadius(float amount)
    {
        ProjectileBlastRadius = ApplyFloatStat(ProjectileBlastRadius, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }

    public void IncreaseProjectileRange(float amount)
    {
        ProjectileRange = ApplyFloatStat(ProjectileRange, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }
    public void IncreaseProjectileSpeed(float amount)
    {
        ProjectileSpeed = ApplyFloatStat(ProjectileSpeed, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }
    public void IncreaseProjectileFireRate(float amount)
    {
        ProjectileFireRate = ApplyFloatStat(ProjectileFireRate, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }
    public void IncreaseMagazineSize(int amount)
    {
        MagazineSize = ApplyIntStat(MagazineSize, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }
    public void IncreaseReloadSpeed(float amount)
    {
        ReloadSpeed = ApplyFloatStat(ReloadSpeed, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
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

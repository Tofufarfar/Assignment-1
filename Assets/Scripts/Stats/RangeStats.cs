using System;
using UnityEngine;

public class RangeStats : Stats
{
    [SerializeField] RangedWeaponData _rangedWeaponData;
    public float _damage { get; private set; }
    public float _projectileBlastRadius { get; private set; }
    public float _projectileRange { get; private set; }
    public float _projectileSpeed { get; private set; }
    public float _projectileFireRate { get; private set; }
    public float _magazineSize { get; private set; }
    public float _reloadSpeed { get; private set; }

    public event Action OnRangeStatsChanged;

    void Awake()
    {
        _projectileBlastRadius = _rangedWeaponData.ProjectileBlastRadius;
        _projectileRange = _rangedWeaponData.ProjectileRange;
        _projectileSpeed = _rangedWeaponData.ProjectileSpeed;
        _projectileFireRate = _rangedWeaponData.FireRate;
        _magazineSize = _rangedWeaponData.MagazineSize;
        _reloadSpeed = _rangedWeaponData.ReloadSpeed;
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
        _damage = ApplyFloatStat(_damage, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }
    public void IncreaseProjectileBlastRadius(float amount)
    {
        _projectileBlastRadius = ApplyFloatStat(_projectileBlastRadius, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }

    public void IncreaseProjectileRange(float amount)
    {
        _projectileRange = ApplyFloatStat(_projectileRange, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }
    public void IncreaseProjectileSpeed(float amount)
    {
        _projectileSpeed = ApplyFloatStat(_projectileSpeed, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }
    public void IncreaseProjectileFireRate(float amount)
    {
        _projectileFireRate = ApplyFloatStat(_projectileFireRate, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }
    public void IncreaseMagazineSize(float amount)
    {
        _magazineSize = ApplyFloatStat(_magazineSize, amount, 0, 9999);
        OnRangeStatsChanged?.Invoke();
    }
    public void IncreaseReloadSpeed(float amount)
    {
        _reloadSpeed = ApplyFloatStat(_reloadSpeed, amount, 0, 9999);
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

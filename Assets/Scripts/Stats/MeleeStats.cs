using System;
using UnityEngine;

public class MeleeStats : Stats
{
    [SerializeField] MeleeWeaponData _meleeWeaponData;

    public event Action OnPlayerStatsChanged;

    public float _damage { get; private set; }
    public float _size { get; private set; }
    public float _swing { get; private set; }
    public float _arc { get; private set; }
    //float LifeLeech => _meleeWeaponData.LifeLeech;
    void Awake()
    {

        _damage = _meleeWeaponData.BaseDamage;
        _size = _meleeWeaponData.WeaponSize;
        _swing = _meleeWeaponData.SwingTimer;
        _arc = _meleeWeaponData.Arc;
    }
    void Start()
    {
        if (UpgradeManager.Instance == null)
        {
            Debug.LogError("UpgradeManager instance is null. Make sure the UpgradeManager is initialized before accessing it.");
        }
        else
        {
            UpgradeManager.Instance.Register(UpgradeData.UpgradeCategory.Melee, this);
        }
    }
    public void IncreaseDamage(int amount) => _damage = ApplyFloatStat(_damage, amount, 0, 9999);
    public void IncreaseSize(int amount) => _size = ApplyFloatStat(_size, amount, 0, 9999);
    public void IncreaseSwingSpeed(int amount) => _swing = ApplyFloatStat(_swing, amount, 0, 9999);
    public void IncreaseArc(int amount) => _arc = ApplyFloatStat(_arc, amount, 0, 360);


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

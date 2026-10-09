using System;
using UnityEngine;

public class MeleeStats : Stats
{
    [SerializeField] MeleeWeaponData _meleeWeaponData;
    [field: SerializeField] public float MaxSize { get; private set; } = 0.99f;

    public float Damage { get; private set; }
    public float Size { get; private set; }
    public float Swing { get; private set; }
    public float Arc { get; private set; }
    //float LifeLeech => _meleeWeaponData.LifeLeech;

    public event Action OnMeleeStatChanged;
    public event Action OnSizeStatChanged;
    void Awake()
    {

        Damage = _meleeWeaponData.BaseDamage;
        Size = _meleeWeaponData.WeaponSize;
        Swing = _meleeWeaponData.SwingTimer;
        Arc = _meleeWeaponData.Arc;
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
    public void IncreaseDamage(int amount) 
    {
        Damage = ApplyFloatStat(Damage, amount, 0, 9999);
        OnMeleeStatChanged?.Invoke();
    } 
    public void IncreaseSize(float amount) 
    {
        Size = ApplyFloatStat(Size, amount, 0, MaxSize);
        OnSizeStatChanged?.Invoke();
    }
    public void IncreaseSwingSpeed(int amount) 
    {
        Swing = ApplyFloatStat(Swing, amount, 0, 9999);
        OnMeleeStatChanged?.Invoke();
    }
    public void IncreaseArc(int amount) 
    {
        Arc = ApplyFloatStat(Arc, amount, 0, 360);
        OnMeleeStatChanged?.Invoke();
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

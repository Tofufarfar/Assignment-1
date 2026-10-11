using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHP { get; private set; }
    public float MaxHP { get; private set; }

    [SerializeField] EnemyData _enemyData;

    public enum DamageType
    {
        Melee,
        Ranged
    }

    float _meleeResist = 0.25f;
    float _rangedResist = 0.25f;

    public event Action<float> HPChanged;
    public event Action<float> MaxHPChanged;
    public event Action OnDeath;
       void Start()
    {
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyMeleeDamage(float damage)
    {
        ApplyDamage(_enemyData.MeleeResist ? _meleeResist * damage : damage);

    }

    public void ApplyRangedDamage(float damage)
    {
        ApplyDamage(_enemyData.RangeResist ? _rangedResist * damage : damage);
    }
    void ApplyDamage(float finalDamage)
    {

        CurrentHP -= finalDamage;

        HPChanged?.Invoke(CurrentHP);
        if(CurrentHP <= 0)
        {
            OnDeath?.Invoke();
            OnDeath = null;
        }
    }

    public void FullHeal()
    {
        CurrentHP = MaxHP;
        HPChanged?.Invoke(CurrentHP);
    }

    public void MaxHealthIncrease(float amount)
    {
        MaxHP += amount;
        CurrentHP = MaxHP;
        MaxHPChanged?.Invoke(MaxHP);
        HPChanged?.Invoke(CurrentHP);
    }

    public void SetMaxHP(float amount)
    {
        MaxHP = amount;
        CurrentHP = MaxHP;
        MaxHPChanged?.Invoke(MaxHP);
        HPChanged?.Invoke(CurrentHP);
    }
}

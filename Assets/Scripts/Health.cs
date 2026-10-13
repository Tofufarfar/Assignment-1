using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHP { get; private set; }
    public float MaxHP { get; private set; }

    [SerializeField] EnemyData _enemyData;
    SpriteRenderer _sr;
    Color _originalColor;
    [SerializeField] Color _resistColor = Color.blue;
    [SerializeField] Color _hitColor = Color.red;
    Coroutine _hitCoroutine;

    public enum DamageType
    {
        Melee,
        Ranged
    }

    float _meleeResist = 0.25f;
    float _rangedResist = 0.25f;
    float _hitDuration = 0.15f;

    public event Action<float> HPChanged;
    public event Action<float> MaxHPChanged;
    public event Action OnDeath;
    void Start()
    {
        CurrentHP = MaxHP;

        if(TryGetComponent<SpriteRenderer>(out _sr))
        {
            _originalColor = _sr.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyMeleeDamage(float damage)
    {
        ApplyDamage(_enemyData.MeleeResist ? _meleeResist * damage : damage);
        if(_enemyData.MeleeResist)
        {
            OnHitResist();
        }
    }

    public void ApplyRangedDamage(float damage)
    {
        ApplyDamage(_enemyData.RangeResist ? _rangedResist * damage : damage);
        if (_enemyData.RangeResist)
        {
            OnHitResist();
        }
    }
    void ApplyDamage(float finalDamage)
    {

        CurrentHP -= finalDamage;
        HPChanged?.Invoke(CurrentHP);
        OnHitIndicator();
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

    public void OnHitResist()
    {
        if (_sr != null)
        {
            if (_hitCoroutine != null)
            {
                StopCoroutine(_hitCoroutine);
            }
            if(gameObject.activeSelf != false)
            {
                _hitCoroutine = StartCoroutine(HitIndicatorResist());
            }
        }
    }

    void OnHitIndicator()
    {
        if(_hitCoroutine != null)
        {
            StopCoroutine(_hitCoroutine);
        }
        if (gameObject.activeSelf != false)
        {
            _hitCoroutine = StartCoroutine(HitIndicator());
        }
    }

    IEnumerator HitIndicator()
    {
        {
            _sr.color = _hitColor;
            yield return new WaitForSeconds(_hitDuration);
            _sr.color = _originalColor;
            _hitCoroutine = null;
        }
    }

    IEnumerator HitIndicatorResist()
    {
        _sr.color = _resistColor;
        yield return new WaitForSeconds(_hitDuration);
        _sr.color = _originalColor;
        _hitCoroutine = null;
    }
}

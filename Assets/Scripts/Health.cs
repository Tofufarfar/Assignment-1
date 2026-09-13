using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHP { get; private set; }
    [field: SerializeField] public float MaxHP { get; private set; }

    public event Action<float> HPChanged;
    public event Action OnDeath;
       void Start()
    {
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        CurrentHP -= damage;

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
}

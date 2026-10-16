using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : WeaponManager
{
    [SerializeField] MeleeWeaponData _meleeWeaponData;
    [SerializeField] MeleeStats _meleeStats;
    [SerializeField] Animator animator;
 
    private void Awake()
    {
       
    }

    private void OnEnable()
    {
        _meleeStats.OnSizeStatChanged += IncreaseSize;
    }

    private void OnDisable()
    {
        _meleeStats.OnSizeStatChanged -= IncreaseSize;
    }
    void IncreaseSize()
    {
        animator.SetFloat("Step", _meleeStats.Size);
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : WeaponManager
{
    [SerializeField] MeleeWeaponData _meleeWeaponData;
    [SerializeField] MeleeStats _meleeStats;
    [SerializeField] Animator _swordEvolve, _attackSwing, _slashEffectSwing;
    [SerializeField] SlashScaleFollow _slashScale;

    float _size;
 
    void Start()
    {
        _attackSwing.SetFloat("AttackSpeed", _meleeStats.Swing);
        _slashEffectSwing.SetFloat("SlashSpeed", _meleeStats.Swing);
    }

    private void OnEnable()
    {
        _meleeStats.OnSizeStatChanged += IncreaseSize;
        _meleeStats.OnMeleeStatChanged += IncreaseSpeed;
    }

    private void OnDisable()
    {
        _meleeStats.OnSizeStatChanged -= IncreaseSize;
        _meleeStats.OnMeleeStatChanged -= IncreaseSpeed;
    }

    private void IncreaseSpeed()
    {
        _attackSwing.SetFloat("AttackSpeed", _meleeStats.Swing);
        _slashEffectSwing.SetFloat("SlashSpeed", _meleeStats.Swing);
    }
    void IncreaseSize()
    {
        _swordEvolve.SetFloat("Step", _meleeStats.Size);
        _size = _swordEvolve.GetFloat("Step");
        _slashScale.SetSizeMultiplier(_size);
    }
}

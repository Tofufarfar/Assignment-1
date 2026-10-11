using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Ammo")]
public class Ammo : ScriptableObject
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float Velocity { get; private set; }
    // [Header("Ammo Properties")]
    // [Range(25, 1000)]
    // [Tooltip("Meters per second")]

    // [Range(1,500)]
    // [Tooltip("Mass in kilograms")]
    // [field: SerializeField] public float Mass { get; private set; }


    //public float KineticEnergyDamage() => 0.5f * Mass * Mathf.Pow(Velocity, 2);

    //public float GetKineticBlastRadius() => Mathf.Sqrt(GetKineticEnergy()) * 0.1f * _rStats.ProjectileBlastRadius;
}

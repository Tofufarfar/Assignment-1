using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Ammo")]
public class Ammo : ScriptableObject
{
    //[SerializeField] RangeStats _rStats;
    [Header("Ammo Properties")]
    [Range(25, 1000)]
    [Tooltip("Meters per second")]
    [field: SerializeField] public float Velocity { get; private set; }
    [Range(1,500)]
    [Tooltip("Mass in kilograms")]
    [field: SerializeField] public float Mass { get; private set; }

   public float GetKineticEnergy() => 0.5f * Mass * Mathf.Pow(Velocity, 2);
    //public float GetKineticBlastRadius() => Mathf.Sqrt(GetKineticEnergy()) * 0.1f * _rStats.ProjectileBlastRadius;
}

using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Ranged")]
public class RangedWeaponData : WeaponData
{
    [field: SerializeField] public float ProjectileBlastRadius { get; private set; }
    [field: SerializeField] public float ProjectileRange { get; private set; }
    [field: SerializeField] public float ProjectileSpeed { get; private set; }
    [field: SerializeField] public float FireRate { get; private set; }
    [field: SerializeField] public int MagazineSize { get; private set; }
    [field: SerializeField] public float ReloadSpeed { get; private set; }
}

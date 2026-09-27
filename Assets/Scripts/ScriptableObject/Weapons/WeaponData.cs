using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{

    public enum WeaponRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }

    [field: SerializeField] public float BaseDamage { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public WeaponRarity Rarity { get; private set; }

    [CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Weapons/Melee")]
    public class MeleeWeaponData : WeaponData
    {
        [field: SerializeField] public float WeaponSize { get; private set; }
        [field: SerializeField] public float SwingTimer { get; private set; }
        [field: SerializeField] public float Arc { get; private set; }
    }

    [CreateAssetMenu(fileName = "New Ranged Weapon", menuName = "Weapons/Ranged")]
    public class RangedWeaponData : WeaponData
    {
        [field: SerializeField] public float ProjectileBlastRadius { get; private set; }
        [field: SerializeField] public float ProjectileRange { get; private set; }
        [field: SerializeField] public float ProjectileSpeed { get; private set; }
        [field: SerializeField] public float FireRate { get; private set; }
        [field: SerializeField] public float MagazineSize { get; private set; }
        [field: SerializeField] public float ReloadTime { get; private set; }
    }

}

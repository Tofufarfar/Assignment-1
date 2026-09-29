using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Melee")]
public class MeleeWeaponData : WeaponData
{
    [field: SerializeField] public float WeaponSize { get; private set; }
    [field: SerializeField] public float SwingTimer { get; private set; }
    [field: SerializeField] public float Arc { get; private set; }
}
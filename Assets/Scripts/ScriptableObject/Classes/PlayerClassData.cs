using UnityEngine;

[CreateAssetMenu]
public class PlayerClassData : ScriptableObject
{
    [field: SerializeField] public float AttackCooldown { get; private set; }
    [field: SerializeField] public float AttackSpeed { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public WeaponData EquippedWeapon { get; private set; }

}

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerClassData : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public int Vacuum { get; private set; }
    [field: SerializeField] public int Armor { get; private set; }
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int XPGain { get; private set; }
    [field: SerializeField] public List<WeaponData> EquippedWeapons { get; private set; } = new List<WeaponData>();

}

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Classes")]
public class PlayerClassData : CharacterData
{
    [field: SerializeField] public float MaxHP { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public int Vacuum { get; private set; }
    [field: SerializeField] public int Armor { get; private set; }
    [field: SerializeField] public int XPGain { get; private set; }
    [field: SerializeField] public List<WeaponData> EquippedWeapons { get; private set; } = new List<WeaponData>();

}

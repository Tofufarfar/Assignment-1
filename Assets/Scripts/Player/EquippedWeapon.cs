using System.Collections.Generic;
using UnityEngine;

public class EquippedWeapon : MonoBehaviour
{
    [SerializeField] List<WeaponData> _equippedWeapons = new List<WeaponData>();

    void AttachWeapon()
    {
        //TODO: Add low chance of monster dropping weapons and attach it to the player
    }

}

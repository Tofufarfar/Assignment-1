using UnityEngine;

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

}

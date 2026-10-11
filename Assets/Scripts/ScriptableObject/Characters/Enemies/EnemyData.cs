using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Enemies")]
public class EnemyData : CharacterData
{
    public enum DamageType
    {
        Melee,
        Ranged
    }

    public enum EnemyType
    {
        Grounded,
        Flying
        
    }

    [field: SerializeField] public EnemyType Type { get; private set; }
    [field: SerializeField] public string Tag { get; private set; }
    [field: SerializeField] public float AttackCooldown { get; private set; }
    [field: SerializeField] public float MaxHP { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float BaseDamage { get; private set; }
    [field: SerializeField] public int ScoreValue { get; private set; }
    [field: SerializeField] public bool MeleeResist { get; private set; }
    [field: SerializeField] public bool RangeResist { get; private set; }
    [field: SerializeField] public DamageType EnemyDamageType { get; private set; }
    
}

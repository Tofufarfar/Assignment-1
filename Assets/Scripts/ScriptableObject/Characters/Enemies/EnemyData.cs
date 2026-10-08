using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Enemies")]
public class EnemyData : CharacterData
{
    [field: SerializeField] public float MaxHP { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float BaseDamage { get; private set; }
    [field: SerializeField] public int ScoreValue { get; private set; }
    [field: SerializeField] public bool MeleeResist { get; private set; }
    [field: SerializeField] public bool RangeResist { get; private set; }
}

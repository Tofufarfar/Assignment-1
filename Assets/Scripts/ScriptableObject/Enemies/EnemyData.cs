using UnityEngine;

[CreateAssetMenuAttribute]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float BaseDamage { get; private set; }
}

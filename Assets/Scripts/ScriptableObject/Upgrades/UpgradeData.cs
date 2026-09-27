using UnityEngine;

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    [field: SerializeField] public string TypeOfUpgrade { get; private set; }
    [field: SerializeField] public float UpgradeIncrement { get; private set; }
}

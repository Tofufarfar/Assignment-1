using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Triangle", transform.position);
    }
}

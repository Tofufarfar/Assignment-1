using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyData[] _enemyData;
    [SerializeField] Transform _player;
    [SerializeField] float _minSpawnRadius = 9f;
    [SerializeField] float _maxSpawnRadius = 33f;
    [SerializeField] float _baseSpawnInterval = 1f;
    [SerializeField] float _difficultySetting = 0.1f;
    [SerializeField] float _difficultyInterval = 15f;
    ObjectPooler objectPooler;
    float nextSpawnTime = 0f;
    float currentDifficulty = 1f;
    float nextDifficultyIncrease;


    private void Start()
    {
        nextDifficultyIncrease = _difficultyInterval;
        objectPooler = ObjectPooler.Instance;

    }
    private void Update()
    {
        float currentTime = InGameTimer.ElapsedTime;

        if (objectPooler == null || _player == null) return;

        if (currentTime >= nextDifficultyIncrease)
        {
            currentDifficulty += _difficultySetting;
            nextDifficultyIncrease += _difficultyInterval;
        }
        if (currentTime >= nextSpawnTime)
        {
            float currentSpawnInterval = _baseSpawnInterval / currentDifficulty;
            nextSpawnTime = currentSpawnInterval + currentTime;
            float i = currentTime % _enemyData.Length;
            objectPooler.SpawnFromPool(_enemyData[(int)i].Tag, SpawnLocation());
            
        }
    }

    Vector2 SpawnLocation()
    {
        Vector2 playerPos = _player.position;
        float angle = UnityEngine.Random.Range(0, Mathf.PI * 2f);
        float radius = Mathf.Sqrt(UnityEngine.Random.Range(_minSpawnRadius * _minSpawnRadius, _maxSpawnRadius * _maxSpawnRadius));

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        return playerPos + new Vector2(x, y);
    }
}

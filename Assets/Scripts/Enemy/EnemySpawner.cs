using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyData[] _enemyData;
    [SerializeField] EnemyData[] _enemyBossData;
    [SerializeField] Transform _player;
    [SerializeField] float _minSpawnRadius = 9f;
    [SerializeField] float _maxSpawnRadius = 33f;
    [SerializeField] float _baseSpawnInterval = 1f;
    [SerializeField] float _difficultySetting = 0.1f;
    [SerializeField] float _difficultyInterval = 15f;
    [SerializeField] float _bossInterval = 10f;
    ObjectPooler objectPooler;
    float _nextSpawnTime = 0f;
    float _currentDifficulty = 1f;
    float _nextDifficultyIncrease;
    float _bossTimer;
    int _bossIndex = 0;
    float _weightedRoll = 0.1f;



    private void Start()
    {
        _nextDifficultyIncrease = _difficultyInterval;
        objectPooler = ObjectPooler.Instance;
    }
    private void Update()
    {
        float currentTime = InGameTimer.ElapsedTime;
        _bossTimer += Time.deltaTime;

        if (objectPooler == null || _player == null) return;

        if (currentTime >= _nextDifficultyIncrease)
        {
            _currentDifficulty += _difficultySetting;
            _nextDifficultyIncrease += _difficultyInterval;
            _weightedRoll += _weightedRoll;
        }
        if (currentTime >= _nextSpawnTime)
        {
            float currentSpawnInterval = _baseSpawnInterval / _currentDifficulty;
            _nextSpawnTime = currentSpawnInterval + currentTime;
            float i = Mathf.Clamp(UnityEngine.Random.Range(0, _enemyData.Length-1 * _weightedRoll),0, _enemyData.Length-1);
            objectPooler.SpawnFromPool(_enemyData[(int)i].Tag, SpawnLocation());
        }

        if(_bossTimer >= _bossInterval && _enemyBossData.Length >= _bossIndex)
        {
            objectPooler.SpawnFromPool(_enemyBossData[_bossIndex].Tag,SpawnLocation());
            if(_bossIndex < _enemyBossData.Length-1)
            {
                _bossIndex++;
            }
            _bossTimer = 0f;
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

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
    [SerializeField] float _bossInterval;
    ObjectPooler objectPooler;
    float _nextSpawnTime = 0f;
    float _currentDifficulty = 1f;
    float _nextDifficultyIncrease;
    float _bossTimer;
    float _weightedRoll = 0.5f;
    float _weightedRollIncrement = 0.05f;
    int _bossIndex = 0;

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
        }
        if (currentTime >= _nextSpawnTime)
        {
            float currentSpawnInterval = _baseSpawnInterval / _currentDifficulty;
            float max = _bossIndex == _enemyData.Length-1 ? _bossIndex :_bossIndex+1;
            _nextSpawnTime = currentSpawnInterval + currentTime;

            float index = Mathf.Clamp(Mathf.Round(UnityEngine.Random.Range(0, max + 1)*_weightedRoll),0,max);
            objectPooler.SpawnFromPool(_enemyData[(int)index].Tag, SpawnLocation());
        }

        if(_bossTimer >= _bossInterval)
        {
            objectPooler.SpawnFromPool(_enemyBossData[_bossIndex].Tag,SpawnLocation());
            if(_bossIndex < _enemyBossData.Length-1)
            {
                _bossIndex++;
            }
            _weightedRoll += _weightedRollIncrement;
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

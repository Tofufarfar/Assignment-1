using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, IPooledObject, IDamageble
{
    [SerializeField] Transform _player;
    [SerializeField] private GameObject xpPrefab;
    [SerializeField] EnemyData _enemyData;
    float _speed, _maxHP, _dmg;
    int _score;
    Rigidbody2D _rb;
    Health _health;
    Vector2 _moveDirection;

    private InGameTimer _igt;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _speed = _enemyData.MovementSpeed;
        _score = _enemyData.ScoreValue;
        _maxHP = _enemyData.MaxHP;
        _dmg = _enemyData.BaseDamage;
    }

    void OnEnable()
    {
        _health.OnDeath += HandleDeath;
    }

    void OnDisable()
    {
        _health.OnDeath -= HandleDeath;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        Vector3 direction = (_player.position - transform.position).normalized;
        _moveDirection = direction;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_moveDirection.x, _moveDirection.y) * _speed;
    }

    void HandleDeath()
    {
        gameObject.SetActive(false);
        ObjectPooler.Instance.SpawnFromPool("XPGem", transform.position);
        Score.Instance.AddScore(_score);
    }

    private void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            collision2D.gameObject.SendMessage("ApplyDamage", _dmg, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void OnObjectSpawned()
    {

    }
}

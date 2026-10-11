using System;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, IPooledObject, IDamageble
{
    [SerializeField] Transform _player;
    [SerializeField] private GameObject xpPrefab;
    [SerializeField] EnemyData _enemyData;
    [SerializeField] Animator anim;
    float _speed, _maxHP, _dmg, _angle, _currentHP, _nextAttackTime;
    int _score;
    Rigidbody2D _rb;
    Health _health;
    Vector3 _moveDirection;

    private InGameTimer _igt;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _speed = _enemyData.MovementSpeed;
        _score = _enemyData.ScoreValue;
        _maxHP = _enemyData.MaxHP;
        _dmg = _enemyData.BaseDamage;

        _health.SetMaxHP(_enemyData.MaxHP);
    }

    void OnEnable()
    {
        _health.HPChanged += OnHit;
        _health.OnDeath += HandleDeath;
    }

    void OnDisable()
    {
        _health.OnDeath -= HandleDeath;
        _health.HPChanged -= OnHit;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _moveDirection = (_player.position - transform.position).normalized;
        if (_enemyData.Type == EnemyData.EnemyType.Grounded)
        {
            float targetY = _moveDirection.x < 0 ? 180f : 0f;
            transform.rotation = Quaternion.Euler(0, targetY, 0);
        }
        else if (_enemyData.Type == EnemyData.EnemyType.Flying)
        {
            _angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
            float targetY = _moveDirection.x < 0 ? 180f : 0f;
            transform.Rotate(new Vector3(targetY, 0, 0));
        }
    }
    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_moveDirection.x, _moveDirection.y) * _speed;
    }

    void HandleDeath()
    {
        gameObject.SetActive(false);
        Score.Instance.AddScore(_score);
        ObjectPooler.Instance.SpawnFromPool("XPGem", transform.position);
    }

    private void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player" && Time.time >= _nextAttackTime)
        {
            _nextAttackTime = Time.time + _enemyData.AttackCooldown;
            anim.SetTrigger("Attack");
            collision2D.gameObject.SendMessage("ApplyDamage", _dmg, SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnHit(float _maxHP)
    {
        //anim.SetTrigger("Hit");
    }

    public void OnObjectSpawned()
    {
        _currentHP = _maxHP;
        //_rb.linearVelocity = new Vector2();
    }
}

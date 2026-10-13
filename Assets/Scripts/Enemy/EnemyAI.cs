using System;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, IPooledObject, IDamageble
{
    [SerializeField] Transform _player;
    [SerializeField] private GameObject _xpPrefab;
    [SerializeField] EnemyData _enemyData;
    [SerializeField] Animator _anim;
    [SerializeField] SpriteRenderer _sr;
    Color _srOriginalColor;
    float _speed, _maxHP, _dmg, _angle, _currentHP, _nextAttackTime, _chargeCoolDown, _chargeDamage;
    float _mass;
    float _chargeEndTime = 0f;
    float _nextChargeAllowedTime = 0f;
    float _chargeDuration = 1f;
    float _chargeSpeed = 16f;
    float _chargeDistance;
    int _score;
    bool _isCharging, _isCharger;
    
    Rigidbody2D _rb;
    Health _health;
    Vector2 _chargeTarget;
    Vector3 _moveDirection;

    private InGameTimer _igt;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _speed = _enemyData.MovementSpeed;
        _score = _enemyData.ScoreValue;
        _maxHP = _enemyData.MaxHP;
        _dmg = _enemyData.BaseDamage;
        _mass = _enemyData.Mass;
        _chargeDamage = _enemyData.ChargeDamage;
        _chargeCoolDown = _enemyData.ChargeCoolDown;
        _chargeDistance = _enemyData.ChargeDistance;
        _isCharger = _enemyData.IsCharger;
        _health.SetMaxHP(_enemyData.MaxHP);
        _srOriginalColor = _sr.color;
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
        if(_isCharging)
        {
            if(Time.time >= _chargeEndTime)
            {
                _isCharging = false;
                _rb.linearVelocity = Vector2.zero;
            }
            return;
        }

        _rb.linearVelocity = new Vector2(_moveDirection.x, _moveDirection.y) * _speed;

        if((transform.position - _player.position).sqrMagnitude < _chargeDistance && _isCharger && Time.time >= _nextChargeAllowedTime)
        {
            Charge();
        }
    }

    void HandleDeath()
    {
        gameObject.SetActive(false);
        Score.Instance.AddScore(_score);
        //TODO If boss explosion of XP gems.
        ObjectPooler.Instance.SpawnFromPool("XPGem", transform.position);
    }

    private void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player" && Time.time >= _nextAttackTime)
        {
            _nextAttackTime = Time.time + _enemyData.AttackCooldown;
            _anim.SetTrigger("Attack");
            collision2D.gameObject.SendMessage("ApplyDamage", _dmg, SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && _isCharging)
        {
            collision.gameObject.SendMessage("ApplyDamage", _chargeDamage, SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnHit(float _maxHP)
    {
        //anim.SetTrigger("Hit");
    }

    

    public void OnObjectSpawned()
    {
        _currentHP = _maxHP;
        _sr.color = _srOriginalColor;
    }

    void SpeedBuildUp()
    {

    }



    void Charge()
    {
        _isCharging = true;
        Vector2 dir = (_player.position - transform.position).normalized;
        _chargeTarget = (Vector2)_player.position + dir * _mass;

        Vector2 travelDir = (_chargeTarget - (Vector2)transform.position).normalized;
        float chargeVelocity = _speed * _chargeSpeed;

        float distance = Vector2.Distance(transform.position, _chargeTarget);
        float duration = Mathf.Approximately(chargeVelocity, 0f) ? _chargeDuration : distance / chargeVelocity;
        _chargeEndTime = Time.time + duration;

        _nextChargeAllowedTime = Time.time + _chargeCoolDown;

        _rb.linearVelocity = travelDir * chargeVelocity;

        _anim?.SetTrigger("Attack");
    }
}

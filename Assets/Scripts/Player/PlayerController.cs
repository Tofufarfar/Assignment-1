using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour, IDamageble
{
    [SerializeField] MeleeStats _mStats;
    [SerializeField] RangeStats _rStats;
    [SerializeField] PlayerStats _pStats;
    [SerializeField] SpriteRenderer _sr;
    InputAction _moveAction;
    Rigidbody2D _rb;
    Health _health;
    [SerializeField] GameObject _weapon;
    float _targetY;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _weapon.transform.RotateAround(transform.position, Vector3.forward, _mStats.Swing * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();
        _rb.linearVelocity = moveValue * _pStats.MovementSpeed;

        _targetY = moveValue.x < 0 ? 180f : 0f;
        _sr.transform.rotation = Quaternion.Euler(0, _targetY, 0);
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDamageble
{
    [SerializeField] MeleeStats _mStats;
    [SerializeField] RangeStats _rStats;
    [SerializeField] PlayerStats _pStats;
    InputAction _moveAction;
    Rigidbody2D _rb;
    Health _health;
    [SerializeField] private GameObject _weapon;
    XP xp;

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
        
    }

    //private void OnCollisionStay2D(Collision2D collision2D)
    //{
    //    if(collision2D.gameObject.tag == "Enemies")
    //    {
          
    //    }
    //}

}

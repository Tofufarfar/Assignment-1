using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] MeleeStats mStats;
    [SerializeField] RangeStats rStats;
    [SerializeField] PlayerStats pStats;
    InputAction moveAction;
    Rigidbody2D rb;
    Health health;
    [SerializeField] private GameObject weapon;
    XP xp;

    private void Awake()
    {
        health = GetComponent<Health>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        weapon.transform.RotateAround(transform.position, Vector3.forward, mStats.Swing * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = moveValue * pStats.MovementSpeed;
        
    }

    private void OnCollisionStay2D(Collision2D collision2D)
    {
        health.TakeDamage(0.01f);
    }

}

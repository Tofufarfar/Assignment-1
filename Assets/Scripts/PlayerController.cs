using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    private float speed = 5f;
    Rigidbody2D rb;
    Health health;
    [SerializeField] private GameObject weapon;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        weapon.transform.RotateAround(transform.position, Vector3.forward, 90 * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = moveValue * speed;
        
    }

    private void OnCollisionStay2D(Collision2D collision2D)
    {
        health.TakeDamage(0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("XPGem"))
        { 
            XP xp = GetComponent<XP>();
            xp.CalculateXP();
            Destroy(collision.gameObject);
        }
        
    }

}

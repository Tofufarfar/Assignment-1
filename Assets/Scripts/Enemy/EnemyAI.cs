using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed = 2f;
    [SerializeField] private GameObject xpPrefab;
    Rigidbody2D rb;
    Health health;
    Vector2 moveDirection;

    public Action<int> EnemyDeathScore;

    private void Awake()
    {
        health = GetComponent<Health>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        moveDirection = direction;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            // TODO : Add damage value to weapon and use it here instead of 1f
            health.TakeDamage(1f);
            if (health.CurrentHP <= 0)
            {
                Destroy(gameObject);
                Instantiate(xpPrefab, transform.position, xpPrefab.transform.rotation);
                Score.instance.AddScore(100);
            }
        }
        
    }

}

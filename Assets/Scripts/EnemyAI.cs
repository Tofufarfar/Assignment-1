using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    //Rigidbody2D rb;
    private float speed = 2f;
    Health health;
    public GameObject xpPrefab;

    private void Awake()
    {
        health = GetComponent<Health>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //  rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate((player.position - transform.position).normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            health.TakeDamage(1f);
            if (health.CurrentHP <= 0)
            {
                Destroy(gameObject);
                Instantiate(xpPrefab, transform.position, xpPrefab.transform.rotation);
            }
        }
        
    }

}

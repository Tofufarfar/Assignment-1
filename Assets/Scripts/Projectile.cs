using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    public Ammo Ammo;
    Vector3 mousePos;
    Camera mainCam;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 180);
    }

    void OnEnable()
    {
        Invoke(nameof(SetFalse), 5f);
    }

    void OnDisable()
    {
        CancelInvoke(nameof(SetFalse));
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        float step = Ammo.Velocity * Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, step);

        if (hit.collider != null)
        {
            transform.position = hit.point;
            Invoke(nameof(SetFalse), 1f);
        }

        transform.Translate(transform.right * step, Space.World);

    }

    void SetFalse()
    {
        gameObject.SetActive(false);
    }
}

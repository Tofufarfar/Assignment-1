using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour, IPooledObject
{
    public Ammo Ammo;
    Vector3 mousePos;
    Camera mainCam;
    Rigidbody2D rb;
    SpriteRenderer sr;
    TrailRenderer tr;
    bool isHit = false;
    public float rotationOffset = -45f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<TrailRenderer>();
    }

    void OnEnable()
    {
        Invoke(nameof(SetFalse), 5f);
    }

    void OnDisable()
    {
        CancelInvoke(nameof(SetFalse));
        StopAllCoroutines();

        tr?.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit) return;
        float step = Ammo.Velocity * Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, step, LayerMask.GetMask("Enemies"));

        if (hit.collider != null)
        {
            isHit = true;
            transform.position = hit.point;
            Debug.Log($"Hit {hit.collider.name}");
            sr.enabled = false;
            //ObjectPooler.Instance.ReturnToPool("Projectiles", gameObject);
            if(sr != null) sr.enabled = false;
            if (tr != null) tr.emitting = false;
            Invoke(nameof(SetFalse), 1f);
            //ApplyDamage(hit.collider.gameObject);
        }

        rb.MovePosition(transform.position + transform.right * step);
        //transform.Translate(transform.right * step, Space.World);

    }

    void SetFalse()
    {
        sr.enabled = false;
        tr?.Clear();
        gameObject.SetActive(false);
        isHit = false;
    }

    public void OnObjectSpawned()
    {
        isHit = false;
        sr.enabled = true;
        if(tr != null)
        {
            tr.Clear();
            tr.emitting = true;
        }
        Vector2 mouseScreen = Mouse.current != null ? Mouse.current.position.ReadValue() : Vector2.zero;
        Vector3 mouseWorld = mainCam != null 
            ? mainCam.ScreenToWorldPoint(new Vector3(mouseScreen.x, mouseScreen.y, Mathf.Abs(mainCam.transform.position.z - transform.position.z)))
            : transform.position;
        Vector3 direction = (mouseWorld - transform.position);
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //Vector3 rotation = transform.position - mousePos;
        //float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 180);
        transform.SetParent(null);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}

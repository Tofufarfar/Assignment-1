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
    [SerializeField] Health health;
    bool isHit = false;
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
            sr.enabled = false;
            if(sr != null) sr.enabled = false;
            if (tr != null) tr.emitting = false;
            hit.collider.SendMessage("ApplyDamage", Ammo.KineticEnergyDamage(), SendMessageOptions.DontRequireReceiver);
            //float dmg = Ammo.GetKineticEnergy();
            //health.TakeDamage(dmg);
            Invoke(nameof(SetFalse), 1f);
        }

        rb.linearVelocity = transform.right * Ammo.Velocity;

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
        transform.SetParent(null);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}

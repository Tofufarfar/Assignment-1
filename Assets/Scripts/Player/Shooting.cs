using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] Transform _firePoint;
    [SerializeField] RangeStats _rangeStats;
    [SerializeField] Ammo _ammo;
    Camera mainCam;
    Vector3 mousePos;
    bool isShooting;
    bool canFire = true;
    bool isReloading;
    float reloadTime = 1f;
    float shootCooldown = 0.5f;
    float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3 lookDir = mousePos - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if(!canFire)
        {
            canFire = false;
            isReloading = true;
            timer += Time.deltaTime;
            if (timer >= reloadTime)
            {
                canFire = true;
                isReloading = false;
                timer = 0f;
            }
        }

        if (canFire)
        {
            Shoot();
            canFire = false;
        }
    }

    private void Shoot()
    {
        var projectile = ObjectPooler.Instance.SpawnFromPool("Projectiles", _firePoint.position);
        projectile.GetComponent<Projectile>().Ammo = _ammo;
    }
}

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
    bool canFire = true;
    bool waitingForFireRate = false;
    int _quiver;
    float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _quiver = _rangeStats.MagazineSize;
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
            timer += Time.deltaTime;
            if (timer >= _rangeStats.ReloadSpeed)
            {
                canFire = true;
                Reload();
                timer = 0f;
            }
        }

        if(waitingForFireRate)
        {
            timer += Time.deltaTime;
            if(timer >= _rangeStats.ProjectileFireRate)
            {
                waitingForFireRate = false;
                timer = 0f;
            }
        }

        if(canFire && _quiver > 0 && !waitingForFireRate)
        {
            Shoot();
            _quiver--;
            waitingForFireRate = true;
            if(_quiver == 0)
            {
                canFire = false;
                timer = 0f;
            }
        }
    }

    private void Shoot()
    {
        var projectile = ObjectPooler.Instance.SpawnFromPool("Projectiles", _firePoint.position);
        projectile.GetComponent<Projectile>().Ammo = _ammo;
    }

    void Reload()
    {
        _quiver = _rangeStats.MagazineSize;
    }
}

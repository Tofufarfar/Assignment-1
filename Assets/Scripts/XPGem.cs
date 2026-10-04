using System;
using UnityEngine;

public class XPGem : MonoBehaviour
{
    Transform _target;
    float _currentSpeed;
    [SerializeField] float _startSpeed = 2f;
    [SerializeField] float _acceleration = 25f;
    public void StartMagnet(Transform target)
    {
        if (target == null) return;
        _target = target;
        _currentSpeed = _startSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null) return;
        _currentSpeed += _acceleration * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (collision.TryGetComponent(out XP xp))
        {
            xp.CalculateXP();
            Destroy(gameObject);
        }

    }

}

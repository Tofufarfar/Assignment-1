using UnityEngine;

[CreateAssetMenu]
public class PlayerClassData : ScriptableObject
{
    [SerializeField] float _attackCooldown;
    [SerializeField] float _attackSpeed;
    [SerializeField] float _moveSpeed;
    [SerializeField] int _maxHealth;
    [SerializeField] WeaponData _equippedWeapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

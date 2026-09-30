using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] PlayerClassData _playerClass;

    int _maxHealth;
    int _percentageXPGain;
    float _movementSpeed;
    float _vacuumEffect;
    float _armor;


    void Awake()
    {
        _maxHealth = _playerClass.MaxHealth;
        _percentageXPGain = _playerClass.XPGain;
        _movementSpeed = _playerClass.MoveSpeed;
        _vacuumEffect = _playerClass.Vacuum;
        _armor = _playerClass.Armor;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

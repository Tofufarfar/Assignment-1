using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float attackCooldown { get; private set; }
    public float attackSpeed { get; private set; }
    public float moveSpeed { get; private set; }
    public int currentHealth { get; private set; }
    public int maxHealth { get; private set; }

    public string equippedWeapon { get; private set; }

    public int playerLevel { get; private set; }

    public int currentXP { get; private set; }

    public int nextLevelXP { get; private set; }

    public int score { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using UnityEngine;

public class XP : MonoBehaviour
{
    public int currentXP { get; private set; } = 0;
    public int playerLevel { get; private set; } = 1;
    public int nextLevelXP { get; private set; } = 5;

    public event Action OnXPGained;
    public event Action OnPlayerLevelUp;
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateXP()
    {
        currentXP++;
        OnXPGained?.Invoke();
        if (currentXP == nextLevelXP && playerLevel >= 40)
        {
            nextLevelXP += 16;
            LevelUp();
        }
        else if (currentXP == nextLevelXP && playerLevel < 40 && playerLevel >= 20)
        {
            nextLevelXP += 13;
            LevelUp();
        }
        else if (currentXP == nextLevelXP && playerLevel < 20)
        {
            nextLevelXP += 10;
            LevelUp();
        }
        
        
    }

    void LevelUp()
    {
        playerLevel++;
        OnPlayerLevelUp?.Invoke();
    }
}

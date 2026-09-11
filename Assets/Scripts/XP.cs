using System;
using UnityEngine;

public class XP : MonoBehaviour
{
    public int currentXP;
    public int playerLevel;
    public int nextLevelXP;

    public event Action XPGained;
    public event Action playerLevelUp;
    private void Awake()
    {
        currentXP = 0;
        playerLevel = 1;
        nextLevelXP = 5;
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
        XPGained?.Invoke();
        if (currentXP == nextLevelXP && playerLevel >= 40)
        {
            nextLevelXP += 16;
            LevelUp();
        }
        else if (currentXP == nextLevelXP && playerLevel < 40 && playerLevel > 20)
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
        playerLevelUp?.Invoke();
    }
}

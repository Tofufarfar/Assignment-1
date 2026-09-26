using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] XP xp;
    [SerializeField] Health health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        xp.OnPlayerLevelUp += ChoosePowerUp;
        health.OnDeath += RestartGame;
    }

    private void RestartGame()
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        xp.OnPlayerLevelUp -= ChoosePowerUp;
        health.OnDeath += RestartGame;
    }

    private void ChoosePowerUp()
    {
        throw new NotImplementedException();
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}

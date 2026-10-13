using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Health _health;
    [SerializeField] PlayerStats _pStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    private void Start()
    {
        _health.SetMaxHP(_pStats.MaxHealth);
    }

    private void OnEnable()
    {
        _health.OnDeath += RestartGame;
    }

    private void OnDisable()
    {
        _health.OnDeath -= RestartGame;    
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

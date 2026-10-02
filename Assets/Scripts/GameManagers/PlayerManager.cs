using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Health _health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

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



    // Update is called once per frame
    void Update()
    {
        
    }
}

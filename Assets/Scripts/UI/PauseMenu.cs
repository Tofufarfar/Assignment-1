using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    bool _isPaused = false;
    [SerializeField] GameObject _pauseMenuUI;
    InputAction _pauseAction;

    private void Awake()
    {
        _pauseAction = InputSystem.actions.FindAction("Pause");
    }

    private void Update()
    {
        if (_pauseAction.WasPressedThisFrame())
        {
            
            if (!_isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    
    void Pause()
    {
        if(Time.timeScale != 0f)
        {
            _pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            _isPaused = true;
        }
                
    }

    public void Resume()
    {
        _pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f;
        _isPaused = false;
    }
}

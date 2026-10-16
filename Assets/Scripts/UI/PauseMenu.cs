using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    bool _isPaused = false;
    [SerializeField] GameObject _pauseMenuUI;
    InputAction _pauseAction;
    InputAction _mainMenu;

    private void Awake()
    {

        _pauseAction = InputSystem.actions.FindAction("Pause");
        _mainMenu = InputSystem.actions.FindAction("MainMenu");
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
        if (_mainMenu.WasPressedThisFrame())
        {

            if (!_isPaused)
            {
                OpenMainMenu();
            }
            else
            {
                MenuManager.Instance.StartGame();
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

    void OpenMainMenu()
    {
        _pauseMenuUI.SetActive(false);
        _isPaused = false;
        MenuManager.Instance.ShowMainMenu();
    }
}

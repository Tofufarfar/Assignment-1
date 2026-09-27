using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    InputAction pauseAction;

    private void Awake()
    {
        pauseAction = InputSystem.actions.FindAction("Pause");
    }

    private void Update()
    {
        if (pauseAction.WasPressedThisFrame())
        {
            
            if (!isPaused)
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
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
    }

    public void Resume()
    {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
    }
}

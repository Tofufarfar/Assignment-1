using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    [SerializeField] GameObject _settingsMenu, _mainMenu;
    [SerializeField] Button _start, _settings, _quit, _back;
    [SerializeField] TextMeshProUGUI _startButtonText;
    [SerializeField] AudioListener _menuAudioListener;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        HideAllMenus();
        //SetMenuSystems(false);
        Time.timeScale = 1f;
        if (!GameState.HasStartedGame)
        {
            GameState.HasStartedGame = true;
            
            HideAllMenus();

        }
        _startButtonText.text = "Resume";
    }
    public void ShowMainMenu()
    {
        Time.timeScale = 0f;
        GoBackToMenu();
    }

    void HideAllMenus()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(false);
    }
    public void GoBackToMenu()
    {
        _mainMenu.SetActive(true);
        _settingsMenu.SetActive(false);
    }

    public void GoToSettings()
    {
        _settingsMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }
    public void Quit()
    {
        if (Application.isEditor)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#endif
        }
        else
        {
            Application.Quit();
        }
    }
}

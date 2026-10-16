using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    [SerializeField] GameObject _settingsMenu, _mainMenu;
    [SerializeField] Button _start, _settings, _quit, _back;
    [SerializeField] TextMeshProUGUI _startButtonText;
    [SerializeField] AudioListener _menuAudioListener;
    [SerializeField] GameObject _mainMenuFirst, _settingsMenuFirst;
    [SerializeField] HideVirtualCursor _hvc;

    void Start()
    {
        Instance = this;
        ShowMainMenu();
        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
        _hvc.SetCursorVisibility(false);
    }
    public void StartGame()
    {
        HideAllMenus();
        Time.timeScale = 1f;
        if (!GameState.HasStartedGame)
        {
            GameState.HasStartedGame = true;
            HideAllMenus();
            _hvc.SetCursorVisibility(true);
        }
        _startButtonText.text = "Resume";
    }
    public void ShowMainMenu()
    {
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
        _mainMenu.SetActive(true);
        _settingsMenu.SetActive(false);
    }

    void HideAllMenus()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void GoToSettings()
    {
        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
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

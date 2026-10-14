using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    [SerializeField] GameObject _settingsMenu, _mainMenu;
    [SerializeField] Button _start, _settings, _quit, _back;
    [SerializeField] TextMeshProUGUI _startButtonText;
    [SerializeField] AudioListener _menuAudioListener;
    [SerializeField] UnityEngine.EventSystems.EventSystem _menuEventSystem;
    public bool IsMenuOpen => _mainMenu.activeSelf || _settingsMenu.activeSelf;

    void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        HideAllMenus();
        SetMenuSystems(false);
        Time.timeScale = 1f;
        if (!GameState.HasStartedGame)
        {
            GameState.HasStartedGame = true;
            StartCoroutine(LoadGameplay());
            
            HideAllMenus();

        }
        _startButtonText.text = "Resume";
    }

    IEnumerator LoadGameplay()
    {
        yield return SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Gameplay"));
    }

    void SetMenuSystems(bool on)
    {
        if (_menuAudioListener != null) _menuAudioListener.enabled = on;
        if (_menuEventSystem != null) _menuEventSystem.enabled = on;
    }

    public void ShowMainMenu()
    {
        Time.timeScale = 0f;
        SetMenuSystems(true);
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

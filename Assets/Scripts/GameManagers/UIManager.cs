//TODO Maybe later

/*using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager Instance;
    [SerializeField] PauseMenu _pauseMenu;
    [SerializeField] LevelUpMenu _levelUpMenu;

    [SerializeField] XP _xp;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public enum State
    {
        Gameplay,
        Paused,
        LevelUp,
        MainMenu,
        Settings
    }

    private void OnEnable()
    {
        _xp.OnPlayerLevelUp += ChangeState;
    }

    private void OnDisable()
    {
        _xp.OnPlayerLevelUp -= ChangeState;
    }

    private State _state;

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            default:
            case State.Gameplay:
                break;
            case State.Paused:
                break;
            case State.LevelUp:
                if(_levelUpMenu.isLevelUpScreen)
                {
                    _levelUpMenu.ShowLevelUpScreen();
                }
                else if (!_levelUpMenu.isLevelUpScreen)
                {
                    _levelUpMenu.HideLevelUpScreen();
                }
                break;
            case State.MainMenu:
                break;
            case State.Settings:
                break;
        }
    }

    public void ChangeState()
    {

    }
    //public void OpenPauseMenu() => pauseMenu.


}
*/
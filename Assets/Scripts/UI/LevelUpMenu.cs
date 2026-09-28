using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    public bool isLevelUpScreen { get; private set; } = false;

    [SerializeField] GameObject _levelUpMenuToHide;
    [SerializeField] GameObject _option1,_option2, _option3;

    [SerializeField] XP _xp;


    void Awake()
    {
        _xp.OnPlayerLevelUp += ShowLevelUpScreen;
    }

    void Start()
    {
        HideLevelUpScreen();
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        _xp.OnPlayerLevelUp -= ShowLevelUpScreen;
    }

    public void ShowLevelUpScreen()
    {
        isLevelUpScreen = true;
        _levelUpMenuToHide.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideLevelUpScreen()
    {
        isLevelUpScreen = false;
        _levelUpMenuToHide.SetActive(false);
        Time.timeScale = 1f;
    }

    void ChooseOption(GameObject option)
    {
        switch (option)
        {
            case var o when o == _option1:
                //GetUpgradeDataOption1();
                break;
            case var o when o == _option2:
                //GetUpgradeDataOption2();
                break;
            case var o when o == _option3:
                //GetUpgradeDataOption3();
                break;
        }
    }
}

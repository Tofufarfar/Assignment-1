using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    public bool isLevelUpScreen { get; private set; } = false;

    [SerializeField] GameObject _levelUpMenuToHide;
    [SerializeField] GameObject _option1,_option2, _option3;
    [SerializeField] TextMeshProUGUI t_option1, t_option2, t_option3;

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
        GetAndChooseUpgrade();
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

    void GetAndChooseUpgrade()
    {
        //FetchUpgradeDataOption1();
        t_option1.text = "Speed";
        //FetchUpgradeDataOption2();
        t_option2.text = "Damage";
        //FetchUpgradeDataOption3();
        t_option3.text = "Size";
    }
}

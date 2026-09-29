using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public bool isLevelUpScreen { get; private set; } = false;

    [SerializeField] GameObject _levelUpMenuToHide;
    [SerializeField] GameObject[] _options;
    [SerializeField] TextMeshProUGUI[] t_options;
    [SerializeField] Color[] _colors;

    [SerializeField] XP _xp;
    [SerializeField] GenerateUpgrade _generateUpgrade;


    void Awake()
    {
        _xp.OnPlayerLevelUp += ShowLevelUpScreen;
    }

    void Start()
    {
        HideLevelUpScreen();
        //TODO LATER NOT PRIO
        //for (var i = 0; i < _options.Length; i++)

        //{
        //    _options[i].GetComponentInChildren<Button>();
        //    _options[i].GetComponentInChildren<Image>();
        //}
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
        UpgradeData[] options = _generateUpgrade.GenerateAndPickOption();
        for (var i = 0; i< options.Length;i++)
        {
            t_options[i].text = (options[i].UpgradeIncrement > 0) ?
            (options[i].GetUpgradeTypeName() + '+' + options[i].UpgradeIncrement).ToString() :
            (options[i].GetUpgradeTypeName() + options[i].UpgradeIncrement).ToString();
        }
    }

    void ApplySelectedOption()
    {

    }

    
    void ApplyRarityBackground()
    {
        // TODO LATER NOT PRIO
        //_options[1].Image._colors[5];
    }

    Color GetColorForRarity(UpgradeData.RarityType rarity) =>
        rarity switch
        {
            UpgradeData.RarityType.Common => _colors[0],
            UpgradeData.RarityType.Uncommon => _colors[1],
            UpgradeData.RarityType.Rare => _colors[2],
            UpgradeData.RarityType.Epic => _colors[3],
            UpgradeData.RarityType.Legendary => _colors[4],
            _ => Color.white
        };
}

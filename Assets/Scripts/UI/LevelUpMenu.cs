using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public bool isLevelUpScreen { get; private set; } = false;

    [SerializeField] GameObject _levelUpMenuToHide;
    [SerializeField] Button[] _optionsButtons;
    [SerializeField] Image[] _optionsImage;
    [SerializeField] TextMeshProUGUI[] _optionsTexts;
    [SerializeField] Color[] _colors;

    [SerializeField] PlayerStats _playerStats;
    [SerializeField] XP _xp;
    [SerializeField] GenerateUpgrade _generateUpgrade;

    UpgradeData[] _currentOptions;

    void Awake()
    {
        _xp.OnPlayerLevelUp += ShowLevelUpScreen;
        _xp.OnPlayerLevelUp += AddListenersToButtons;
    }

    void Start()
    {
        HideLevelUpScreen();
    }

    private void AddListenersToButtons()
    {
        for (int i = 0; i < _optionsButtons.Length; i++)
        {
            int j = i;
            _optionsButtons[i].onClick.AddListener(() => ApplySelectedOption(j));
        }
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        _xp.OnPlayerLevelUp -= ShowLevelUpScreen;
        _xp.OnPlayerLevelUp -= AddListenersToButtons;
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

        for (var i = 0; i < options.Length; i++)
        {
            var opt = options[i];
            _optionsImage[i].sprite = options[i].UpgradeIcon;
            _optionsTexts[i].text = options[i].UpgradeDescription;
            //_optionsTexts[i].text = (options[i].UpgradeIncrement >= 1) ?
            //(options[i].UpgradeDescription + " +" + options[i].UpgradeIncrement):
            //(options[i].UpgradeDescription + " +" + options[i].UpgradeIncrement * 100);
            _optionsButtons[i].interactable = true;
            _optionsButtons[i].image.color = GetColorForRarity(opt.Rarity);
            _currentOptions = options;
        }
    }
    void ApplySelectedOption(int index)
    {
        if (_optionsButtons == null || index < 0 || index >= _optionsButtons.Length) return;
        var chosen = _optionsButtons[index];
        var opt = _currentOptions[index];
        var targetStats = UpgradeManager.Instance.GetStatsForCategory(opt.Category);
        opt.ApplyUpgrade(targetStats);
        HideLevelUpScreen();
        RemoveListenersFromButtons();
    }

    private void RemoveListenersFromButtons()
    {
        for(int i = 0; i < _optionsButtons.Length; i++)
        {
            _optionsButtons[i].onClick.RemoveAllListeners();
        }
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

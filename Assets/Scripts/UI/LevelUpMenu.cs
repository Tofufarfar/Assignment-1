using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public bool isLevelUpScreen { get; private set; } = false;
    public bool isAutoUpgrade { get; private set; } = false;

    [SerializeField] GameObject _levelUpMenuToHide;
    [SerializeField] Button[] _optionsButtons;
    [SerializeField] Button _autoUpgradeButton;
    [SerializeField] Image[] _optionsImage;
    [SerializeField] Image _buttonImage;
    [SerializeField] TextMeshProUGUI[] _optionsTexts;
    [SerializeField] Color[] _colors;
    [SerializeField] Color _on, _off;

    [SerializeField] PlayerStats _playerStats;
    [SerializeField] XP _xp;
    [SerializeField] GenerateUpgrade _generateUpgrade;
    [SerializeField] GameObject _defaultButton;


    UpgradeData[] _currentOptions;
  

    void Awake()
    {
        _xp.OnPlayerLevelUp += ShowLevelUpScreen;
        _xp.OnPlayerLevelUp += AddListenersToButtons;
        _autoUpgradeButton.onClick.AddListener(ToggleAutoUpgrade);
    }

    private void AddListenersToButtons()
    {
        if(!isAutoUpgrade)
        {
            for (int i = 0; i < _optionsButtons.Length; i++)
            {
                int j = i;
                _optionsButtons[i].onClick.AddListener(() => ApplySelectedOption(j));
            }
        }
        else
        {
            int rand = UnityEngine.Random.Range(0, 2);
            ApplySelectedOption(rand);
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
    private void ToggleAutoUpgrade()
    {
        isAutoUpgrade = !isAutoUpgrade;
        ToggleColor();
    }

    private void ToggleColor()
    {
        _buttonImage.color = isAutoUpgrade ? _on : _off; 
    }
    public void ShowLevelUpScreen()
    {
        GetAndChooseUpgrade();
        if (!isAutoUpgrade)
        {
            EventSystem.current.SetSelectedGameObject(_defaultButton);
            isLevelUpScreen = true;
            _levelUpMenuToHide.SetActive(true);
            Time.timeScale = 0f;
        }
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

        if (!isAutoUpgrade)
        {
            for (var i = 0; i < options.Length; i++)
            {
                var opt = options[i];
                _optionsImage[i].sprite = options[i].UpgradeIcon;
                _optionsTexts[i].text = options[i].UpgradeDescription;
                _optionsButtons[i].interactable = true;
                _optionsButtons[i].image.color = GetColorForRarity(opt.Rarity);
                _currentOptions = options;
            }
        }
        
    }
    void ApplySelectedOption(int index)
    {
        if (_optionsButtons == null || index < 0 || index >= _optionsButtons.Length) return;
        var chosen = _optionsButtons[index];
        var opt = _currentOptions[index];
        var targetStats = UpgradeManager.Instance.GetStatsForCategory(opt.Category);
        opt.ApplyUpgrade(targetStats);
        if (!isAutoUpgrade)
        {
            HideLevelUpScreen();
            RemoveListenersFromButtons();
        }
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

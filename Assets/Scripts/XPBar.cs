using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    [SerializeField] private Slider ExperienceBar;
    [SerializeField] private TextMeshProUGUI PlayerLevels;
    private XP xp;

    private void Awake()
    {
        xp = GetComponentInParent<XP>();
        ExperienceBar.maxValue = xp.nextLevelXP;
        ExperienceBar.value = xp.currentXP;
    }

    private void OnEnable()
    {
        xp.OnPlayerLevelUp += ResetXPBar;
        xp.OnPlayerLevelUp += IncreasePlayerLevelText;
        xp.OnXPGained += SetXPBar;
    }

    private void OnDisable()
    {
        xp.OnPlayerLevelUp -= ResetXPBar;
        xp.OnPlayerLevelUp -= IncreasePlayerLevelText;
        xp.OnXPGained -= SetXPBar;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void SetXPBar()
    {
        ExperienceBar.value = xp.currentXP;
    }

    void ResetXPBar()
    {
        ExperienceBar.maxValue = xp.nextLevelXP;
        ExperienceBar.minValue = xp.currentXP;
    }

    void IncreasePlayerLevelText()
    {
        PlayerLevels.text = ("Lvl: " + xp.playerLevel);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    Slider ExperienceBar;
    XP XP;

    private void Awake()
    {
        ExperienceBar = GetComponent<Slider>();
        XP = GetComponentInParent<XP>();
        ExperienceBar.maxValue = XP.nextLevelXP;
        ExperienceBar.value = XP.currentXP;
    }

    private void OnEnable()
    {
        XP.playerLevelUp += ResetXPBar;
        XP.XPGained += SetXPBar;
    }

    private void OnDisable()
    {
        XP.playerLevelUp -= ResetXPBar;
        XP.XPGained -= ResetXPBar;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void SetXPBar()
    {
        ExperienceBar.value = XP.currentXP;
    }

    void ResetXPBar()
    {
        ExperienceBar.maxValue = XP.nextLevelXP;
        ExperienceBar.minValue = XP.currentXP;
    }

}

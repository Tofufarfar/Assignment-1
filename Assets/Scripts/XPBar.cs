using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    private Slider ExperienceBar;
    private XP xp;

    private void Awake()
    {
        ExperienceBar = GetComponent<Slider>();
        xp = GetComponentInParent<XP>();
        ExperienceBar.maxValue = xp.nextLevelXP;
        ExperienceBar.value = xp.currentXP;
    }

    private void OnEnable()
    {
        xp.OnPlayerLevelUp += ResetXPBar;
        xp.OnXPGained += SetXPBar;
    }

    private void OnDisable()
    {
        xp.OnPlayerLevelUp -= ResetXPBar;
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

}

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider hpBar;
    Health hp;
    XP xp;

    private void Awake()
    {
        hpBar = GetComponent<Slider>();
        hp = GetComponentInParent<Health>();
        xp = GetComponentInParent<XP>();
        hpBar.maxValue = hp.MaxHP;
        hpBar.value = hp.MaxHP;
    }

    private void OnEnable()
    {
        hp.HPChanged += SetHPBar;
        xp.OnPlayerLevelUp += hp.FullHeal;
    }

    private void OnDisable()
    {
       hp.HPChanged -= SetHPBar;
       xp.OnPlayerLevelUp -= hp.FullHeal;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SetHPBar(float currentHP)
    { 
        hpBar.value = currentHP;
    }

}

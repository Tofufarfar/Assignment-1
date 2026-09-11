using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider HPBar;
    Health HP;

    private void Awake()
    {
        HPBar = GetComponent<Slider>();
        HP = GetComponentInParent<Health>();
        HPBar.maxValue = HP.MaxHP;
        HPBar.value = HP.MaxHP;
    }

    private void OnEnable()
    {
        HP.HPChanged += SetHPBar;
    }

    private void OnDisable()
    {
       HP.HPChanged -= SetHPBar; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SetHPBar(float currentHP)
    { 
        HPBar.value = currentHP;
    }

}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
    [SerializeField] Button _showStats;
    [SerializeField] GameObject _panel;
    [SerializeField] TextMeshProUGUI[] _statText;
    [SerializeField] PlayerStats _pStats;
    [SerializeField] RangeStats _rStats;
    [SerializeField] MeleeStats _mStats;


    void Start()
    {
        _statText[0].text = "Melee Damage: " + _mStats.Damage.ToString();
        _statText[1].text = "Sword Size: " + _mStats.Size.ToString();
        _statText[2].text = "Swing Speed: " + _mStats.Swing.ToString();
        _statText[3].text = "Projectile Damage: " + _rStats.ProjectileDamage.ToString();
        _statText[4].text = "Reload Speed: " + _rStats.ReloadSpeed.ToString();
        _statText[5].text = "Fire Rate: " + _rStats.ProjectileFireRate.ToString();
        _statText[6].text = "Quiver Size: " + _rStats.MagazineSize.ToString();
        _statText[7].text = "Vacuum Effect: " + _pStats.VacuumEffect.ToString();
        _statText[8].text = "Movement Speed: " + _pStats.MovementSpeed.ToString();
        _statText[9].text = "Max Health: " + _pStats.MaxHealth.ToString();
    }

    private void OnEnable()
    {
        _pStats.OnMaxHealthIncrease += _pStats_OnMaxHealthIncrease;
        _pStats.OnPlayerStatsChanged += _pStats_OnPlayerStatsChanged;
        _rStats.OnRangeStatsChanged += _rStats_OnRangeStatsChanged;
        _mStats.OnSizeStatChanged += _mStats_OnSizeStatChanged;
        _mStats.OnMeleeStatChanged += _mStats_OnMeleeStatChanged;
    }

    private void OnDisable()
    {
        _pStats.OnMaxHealthIncrease -= _pStats_OnMaxHealthIncrease;
        _pStats.OnPlayerStatsChanged -= _pStats_OnPlayerStatsChanged;
        _rStats.OnRangeStatsChanged -= _rStats_OnRangeStatsChanged;
        _mStats.OnSizeStatChanged -= _mStats_OnSizeStatChanged;
        _mStats.OnMeleeStatChanged -= _mStats_OnMeleeStatChanged;
    }

    private void _mStats_OnSizeStatChanged()
    {
        _statText[1].text = "Sword Size: "+_mStats.Size.ToString();
    }
    private void _mStats_OnMeleeStatChanged()
    {
        _statText[0].text = "Melee Damage: "+_mStats.Damage.ToString();
        _statText[2].text = "Swing Speed: "+_mStats.Swing.ToString();
    }

    private void _rStats_OnRangeStatsChanged()
    {
        _statText[3].text = "Projectile Damage: "+_rStats.ProjectileDamage.ToString();
        _statText[4].text = "Reload Speed: "+_rStats.ReloadSpeed.ToString();
         _statText[5].text = "Fire Rate: "+_rStats.ProjectileFireRate.ToString();
        _statText[6].text = "Quiver Size: "+_rStats.MagazineSize.ToString();
    }

    private void _pStats_OnPlayerStatsChanged()
    {
        _statText[7].text = "Vacuum Effect: "+_pStats.VacuumEffect.ToString();
        _statText[8].text = "Movement Speed: "+_pStats.MovementSpeed.ToString();
    }
    private void _pStats_OnMaxHealthIncrease()
    {
        _statText[9].text = "Health: " + _pStats.MaxHealth.ToString();
    }

    public void ShowStats()
    {
        if(!_panel.activeSelf)
        {
            _panel.SetActive(true);
        }
        else if (_panel.activeSelf)
        {
            _panel.SetActive(false);
        }
    }
}

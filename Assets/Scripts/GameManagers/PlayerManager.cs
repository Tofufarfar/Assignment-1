using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Health _health;
    [SerializeField] PlayerStats _pStats;
    [SerializeField] XP _xp;
    [SerializeField] AudioClip[] _levelUpSounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    private void Start()
    {
        _health.SetMaxHP(_pStats.MaxHealth);
    }

    private void OnEnable()
    {
        _health.OnDeath += RestartGame;
        _xp.OnPlayerLevelUp += PlayLevelUpSound;
    }

    private void OnDisable()
    {
        _health.OnDeath -= RestartGame;    
    }

    void PlayLevelUpSound()
    {
        SoundManager.Instance.PlayRandomSound(_levelUpSounds, _player, 1);
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

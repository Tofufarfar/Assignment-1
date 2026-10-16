using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Button _back, _confirm;
    [SerializeField] Slider _master, _music, _sfx;
    [SerializeField] GameObject _mainMenu;
    SoundMixerManager _soundMixerManager;

    void Awake()
    {
        _soundMixerManager = SoundMixerManager.Instance;
    }

    void Start()
    {
        _master.onValueChanged.AddListener(v => _soundMixerManager?.SetMasterVolume(v));
        _music.onValueChanged.AddListener(v => _soundMixerManager?.SetMusicVolume(v));
        _sfx.onValueChanged.AddListener(v => _soundMixerManager?.SetSFXVolume(v));
    }

}

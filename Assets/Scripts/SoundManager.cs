using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource _soundObject;
    public static SoundManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySound(AudioClip audioClip, Transform soundPos,float volume)
    {
        AudioSource _audioSource = Instantiate(_soundObject,soundPos.position, Quaternion.identity);

        _audioSource.clip = audioClip;
        _audioSource.volume = volume;
        _audioSource.Play();

        float clipLength = _audioSource.clip.length;
        Object.Destroy(_audioSource, clipLength);
    }

    public void PlayRandomSound(AudioClip[] audioClip, Transform soundPos, float volume)
    {
        AudioSource _audioSource = Instantiate(_soundObject, soundPos.position, Quaternion.identity);
        int rand = Random.Range(0, audioClip.Length);
        _audioSource.clip = audioClip[rand];
        _audioSource.volume = volume;
        _audioSource.Play();

        float clipLength = _audioSource.clip.length;
        Object.Destroy(_audioSource, clipLength);
    }
}

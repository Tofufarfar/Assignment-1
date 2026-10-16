using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGM : MonoBehaviour
{
    [SerializeField] AudioClip[] _backGroundMusics;
    int _currentSong;

    public static BGM Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        var audio = GetComponent<AudioSource>();
        audio.loop = true;
        if (!audio.isPlaying) audio.Play();
    }

    void Start()
    {
        
    }

}

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class MainMusic : MonoBehaviour
{
    public AudioSource Music => _music;
    public static MainMusic Audio;
    
    private AudioSource _music;
    private AudioData _audioData = new();

    private void Start()
    {
        if(Audio == null)
        {
            Audio = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
        _music = GetComponent<AudioSource>();
        Play();
    }
    private void Play()
    {
        var audioValues = _audioData.Load();
        if (audioValues.MusicOn)
            _music.Play();
    }
}

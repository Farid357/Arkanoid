using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class BallSound : MonoBehaviour
{
    private readonly AudioData _audioData = new();
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        BallCollision.OnEnter += Play;
    }
    private void OnDisable()
    {
        BallCollision.OnEnter -= Play;
    }
    private void Play()
    {
        var audioValues = _audioData.Load();
        if (audioValues.SoundOn)
        {
            _audioSource.pitch = Random.Range(0.8f, 1.2f);
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}

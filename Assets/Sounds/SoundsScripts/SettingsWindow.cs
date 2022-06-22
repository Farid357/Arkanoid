using UnityEngine;

public sealed class SettingsWindow : MonoBehaviour
{
    [SerializeField] private AudioButton _musicButton;
    [SerializeField] private AudioButton _soundButton;
    private AudioValues _audioValues;
    private readonly AudioData _audioData = new();

    private void OnEnable()
    {
        _audioValues = _audioData.Load();
        _musicButton.SetState(_audioValues.MusicOn);
        _soundButton.SetState(_audioValues.SoundOn);
    }
    public void ChangeSoundState()
    {
        _audioData.ChangeSound();
    }
    public void ChangeMusicState()
    {
        _audioData.ChangeMusic();
    }
    public void DeleteProgress()
    {
        LevelsData levelsData = new LevelsData();
        levelsData.Delete();
    }
}


using UnityEngine;

public class AudioData
{
    private readonly string _key;

    private AudioValues _audioValues = new();
    private PlayerPrefsStorage _storage = new();

    public AudioData()
    {
        _key = Application.persistentDataPath + "Music";
    }
    public AudioValues Load()
    {
        if (_storage.Exists(_key))
        {
            _audioValues = _storage.Load(_key, _audioValues);
        }
        else
        {
            CreateNew();
        }
        return _audioValues;
    }
    public void ChangeSound()
    {
        _audioValues.SoundOn = !_audioValues.SoundOn;
        Save();
    }
    public void ChangeMusic()
    {
        _audioValues.MusicOn = !_audioValues.MusicOn;
        if (_audioValues.MusicOn)
            MainMusic.Audio.Music.Play();
        else
            MainMusic.Audio.Music.Stop();

        Save();
    }
    public void Save()
    {
        _storage.Save(_key, _audioValues);
    }
    private void CreateNew()
    {
        _audioValues.SoundOn = true;
        _audioValues.MusicOn = true;
        Save();
    }
}

[System.Serializable]
public class AudioValues
{
    public bool MusicOn;
                      
    public bool SoundOn;
}

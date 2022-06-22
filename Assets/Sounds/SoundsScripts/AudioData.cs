
public class AudioData
{
    private const string Key = "Musickey";

    private AudioValues _audioValues = new();
    private PlayerPrefsStorage _storage = new();

    public AudioValues Load()
    {
        if (_storage.Exists(Key))
        {
            _audioValues = _storage.Load(Key, _audioValues);
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
        _storage.Save(Key, _audioValues);
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

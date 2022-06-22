using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class LevelsData
{
    private int _levelCount;
    private string _path;

    private LevelsProgress _LevelsProgress = new();
    private BinaryStorage _storage;

    public LevelsData(int count = 10)
    {
        _storage = new();
        _path = Path.Combine(Application.persistentDataPath + "LevelsData.txt");
        _levelCount = count;
    }
    public LevelsProgress LoadData()
    {      
        if (_storage.Exists(_path))
        {
            _LevelsProgress = _storage.Load(_path, _LevelsProgress);
        }
        else
        {
            CreateNewLevelsProgress();
        }
        return _LevelsProgress;
    }
    public void Save(LevelsProgress levelsProgress)
    {
        _storage.Save(_path, levelsProgress);
    }
    public void CreateNewLevelsProgress()
    {
        for (int i = 0; i < _levelCount; i++)
        {
            _LevelsProgress.Progresses.Add(new Progress());
        }
        _LevelsProgress.Progresses[0].IsOpened = true;
        Save(_LevelsProgress);
    }
    public void SaveLevelData(int levelIndex, Progress progress)
    {
        if (levelIndex < 0 || levelIndex > _levelCount)
            throw new ArgumentOutOfRangeException("Level index not correct!");

        _LevelsProgress.Progresses[levelIndex] = progress;
        _LevelsProgress.Progresses[levelIndex + 1].IsOpened = true;
        Save(_LevelsProgress);
    }
    public void Delete()
    {
        if (_storage.Exists(_path))
        {
            _storage.Delete(_path);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }    
    }
}

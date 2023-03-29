using UnityEngine;
using System;

public sealed class ScoreCollector : MonoBehaviour
{
    public event Action<int, int> OnChanged;
    public int ScoreCount => _scoreCount;
    public int BestScore => _bestScore;
   
    private BinaryStorage _storage = new();
    private string _key;
    private int _bestScore;
    private int _scoreCount;

    private void OnEnable()
    {
        _key = Application.persistentDataPath + "Score";
        _bestScore = _storage.Load(_key, _bestScore);
        BlockHealth.OnEnded += Add;
    }
    private void OnDisable()
    {
        BlockHealth.OnEnded -= Add;
    }
    private void Add(int count)
    {
        _scoreCount += count;
        var previousCount = _scoreCount - count;
        TrySetNewRecord();
        OnChanged.Invoke(_scoreCount, previousCount);
    }
    private void TrySetNewRecord()
    {
        if (_bestScore < _scoreCount)
        {
            _bestScore = _scoreCount;
            Save();
        }
    }
    private void Save()
    {
        _storage.Save(_key, _bestScore);
    }
}

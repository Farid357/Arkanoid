using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public sealed class GameEndView : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private GameCleaner _gameCleaner;
    [SerializeField] private SpriteRenderer _levelImage;
    [SerializeField] private GameObject[] _starsVariants;

    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private ScoreCollector _collector;
    [SerializeField] private LevelIndex _levelIndex;

    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _levelText;

    [SerializeField] private Color _defeatColor;
    [SerializeField] private Color _winColor;
    private int _index;

    private void OnEnable()
    {
        _playerHealth.OnEnd += Enable;
        Block.OnGameEnded += Enable;
    }
    private void OnDisable()
    {
        _playerHealth.OnEnd -= Enable;
        Block.OnGameEnded -= Enable;
    }
    private void Enable()
    {
        Show();
    }
    private void Display()
    {
        _index = _levelIndex.Get();
        _scoreText.text = _collector.ScoreCount.ToString();
        _bestScoreText.text = _collector.BestScore.ToString();
        _levelText.text = Convert.ToString(_index + 1);
        _endGamePanel.SetActive(true);
        if (_playerHealth.Health > 0)
        {
            _levelImage.color = _winColor;
        }
        else
            _levelImage.color = _defeatColor;
    }
    private void Show()
    {
        Display();
        _index = _levelIndex.Get();

        var starsCount = _playerHealth.Health;
        _nextLevelButton.interactable = starsCount > 0;
        if (starsCount > 3)
            starsCount = 3;

        _starsVariants[starsCount].gameObject.SetActive(true);

        var levelsData = new LevelsData();
        var levelsProgress = new LevelsProgress();
        levelsProgress = levelsData.LoadData();
        if (levelsProgress.Progresses[_index + 1].IsOpened)
            _nextLevelButton.interactable = true;
        if (starsCount > levelsProgress.Progresses[_index].StarsCount)
        {
            levelsProgress.Progresses[_index].StarsCount = starsCount;
            levelsData.SaveLevelData(_index, levelsProgress.Progresses[_index]);
        }   
        _gameCleaner.Clear();
        _gameState.Pause();
    }
}

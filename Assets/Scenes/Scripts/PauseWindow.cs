using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class PauseWindow : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private LevelIndex _levelIndex;
    private bool _isPause;

    public void GoToHome()
    {
        _sceneLoader.Load(0);
    }
    public void Restart()
    {
        _sceneLoader.Load(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToNextLevel()
    {
        var levelsProgress = new LevelsProgress();
        var levelsData = new LevelsData();
        int index = _levelIndex.Get() + 1;
        Debug.Log(index);
        levelsProgress = levelsData.LoadData();
        if (levelsProgress.Progresses[index].IsOpened)
        {
            _sceneLoader.Load(index);
        }
        else
            Debug.LogWarning("Next level is not opened!");
    }
    public void Pause()
    {
        if (_isPause)
            Continue();
        else
        {
            _pausePanel.gameObject.SetActive(true);
            _isPause = true;
            Time.timeScale = 0;
        }
    }
    public void Continue()
    {
        _pausePanel.gameObject.SetActive(false);
        _isPause = false;
        Time.timeScale = 1;
    }
}

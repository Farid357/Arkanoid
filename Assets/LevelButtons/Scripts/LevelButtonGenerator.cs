using UnityEngine;


public sealed class LevelButtonGenerator : MonoBehaviour
{
    [SerializeField] private LevelButton _buttonPrefab;

    [SerializeField, Min(5)] private int _levels = 10;
    [SerializeField] private GameObject _content;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        var levelsProgress = new LevelsProgress();

        levelsProgress = new LevelsData().LoadData();

        for (int i = 0; i < _levels; i++)
        {
            var levelButton = Instantiate(_buttonPrefab, _content.transform);
            levelButton.name += "1";
            levelButton.SetData(i + 1, levelsProgress.Progresses[i]);
        }
    }
}

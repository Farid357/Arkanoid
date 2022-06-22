using UnityEngine;

[RequireComponent(typeof(LevelButton))]
public sealed class LevelIndex : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    private LevelButton _levelButton;
    private const string Key = "Level index";
    private int _index;

    private void Start()
    {
        _levelButton = GetComponent<LevelButton>();
        _index = _levelButton.Index - 1;
    }

    public int Get()
    {
        _index = PlayerPrefs.GetInt(Key);
        return _index;
    }
    public void OnClick()
    {
        PlayerPrefs.SetInt(Key, _index);
        _sceneLoader.Load(_index + 2);
    }
}

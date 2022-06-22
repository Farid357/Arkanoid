using UnityEngine;
using TMPro;
using UnityEngine.UI;

public sealed class LevelButton : MonoBehaviour
{
    public int Index => _index;

    [SerializeField] private Button _levelButton;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private GameObject[] _starsSprites;
    [SerializeField] private int _index;

    public void SetData(int index, Progress progress)
    {
        _levelButton.interactable = progress.IsOpened;
        _starsSprites[progress.StarsCount].gameObject.SetActive(true);
        if(progress.StarsCount > 0)
        _starsSprites[0].gameObject.SetActive(false);
        _buttonText.text = index.ToString();
        _index = index;
    }
}

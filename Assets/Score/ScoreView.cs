using System.Collections;
using TMPro;
using UnityEngine;

public sealed class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCollector _collector;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private WaitForSeconds _wait;

    private void OnEnable()
    {
        _wait = new WaitForSeconds(0.025f);
         _collector.OnChanged += Display;
    }
    private void OnDisable()
    {
        _collector.OnChanged -= Display;
    }
    private void Display(int count, int previousCount)
    {
        StartCoroutine(Calculate(count, previousCount));
    }
    private IEnumerator Calculate(int count, int previousCount)
    {
        while (previousCount < count)
        {
            previousCount++;
            _scoreText.text = previousCount.ToString();
            yield return _wait;
        }
    }
}

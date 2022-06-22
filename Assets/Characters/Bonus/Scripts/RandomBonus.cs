using UnityEngine;
using System.Collections;

public sealed class RandomBonus : Bonus
{
    [SerializeField] private Color[] _colors;
    [SerializeField, Range(1, 2)] private int _additionHealth = 1;

    private PlayerHealth _playerHealth;
    private SpriteRenderer _spriteRenderer;

    public void Init(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
    }

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }
    protected override void Apply()
    {
        int index = Random.Range(0, 2);
        if (index == 1)
            _playerHealth.Increase(_additionHealth);
    }

    private Color GetRandomColor(Color[] colors)
    {
        int index = Random.Range(0, colors.Length);
        return colors[index];
    }
    private IEnumerator ChangeColor()
    {
        float time = 0;
        var color = GetRandomColor(_colors);
        while (time < WaitTime)
        {
            _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, color, time);
            time += Time.deltaTime;
            yield return null;
        }
        yield return StartCoroutine(ChangeColor());
    }
}

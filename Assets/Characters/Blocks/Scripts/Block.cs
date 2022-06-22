using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Block : MonoBehaviour
{
    public static event Action<Vector3> OnDestroyed;
    public static event Action OnGameEnded;
    public List<Sprite> Sprites => _sprites;
    public int Score => _score;

    private static int _count;

    [SerializeField] private int _score;

    [SerializeField] private List<Sprite> _sprites = new();
    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        _count++;
    }
    private void OnDisable()
    {
        _count--;
        if (_count > 0)
            OnDestroyed?.Invoke(transform.position);
        if (_count <= 0)
        {
            OnGameEnded?.Invoke();
        }
    }
    public void SetData(ColoredBlock data)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = data.Color;
        _score = data.Score;
        _sprites = data.Sprites;
        _spriteRenderer.sprite = _sprites[_sprites.Count - 1];
    }
}
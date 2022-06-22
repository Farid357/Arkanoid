using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using System;

public sealed class BlockHealth : MonoBehaviour, IDamagable
{
    public static event Action<int> OnEnded;
    private Block _block;
    private int _health;

    private List<Sprite> _sprites = new();
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _block = GetComponent<Block>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _health = _block.Sprites.Count;
        _sprites = _block.Sprites;
        MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = _spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy();
        }
        else
        {
            if (_sprites.Count >= 1)
            {
                _spriteRenderer.sprite = _sprites[_health - 1];
            }
        }
    }
    private void Destroy()
    {
        OnEnded.Invoke(_block.Score);
        GetComponent<ParticleSystem>().Play();
        _spriteRenderer.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}

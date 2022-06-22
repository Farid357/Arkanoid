using UnityEngine;
using System;

public sealed class PlayerHealth : MonoBehaviour
{
    public event Action OnEnd;

    public event Action OnChanged;
    public int Health => _health;

    [SerializeField, Range(1, 20)] private int _health = 3;

    private void OnEnable()
    {
        BallCount.OnEnded += TakeDamage;
    }
    private void OnDisable() => BallCount.OnEnded -= TakeDamage;
    private void Start() => OnChanged?.Invoke();

    public void Increase(int value)
    {
        _health += value;
        OnChanged.Invoke();
    }
    private void TakeDamage()
    {
        _health -= 1;
        OnChanged?.Invoke();

        if (_health <= 0)
        {
            OnEnd.Invoke();
            _health = 0;
        }
    }
}

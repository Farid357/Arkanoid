using UnityEngine;
using System;

public sealed class BallCount : MonoBehaviour
{
    public static event Action OnEnded;
    private static int _count;

    private void OnEnable()
    {
        _count++;
    }
    private void OnDisable()
    {
        _count--;
        if (_count <= 0)
            OnEnded?.Invoke();

    }
}

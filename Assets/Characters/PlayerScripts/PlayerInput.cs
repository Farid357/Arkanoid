using System;
using UnityEngine;

public sealed class PlayerInput : MonoBehaviour
{
    public event Action<float> OnMoved;
    private Vector2 _startPosition;
    private float _direction;

    private void Update()
    {
#if UNITY_EDITOR
        OnMoved.Invoke(Input.GetAxis("Horizontal"));
#endif

#if UNITY_ANDROID
        GetTouch();
#endif
    }
    private void GetTouch()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (touch.position.x > _startPosition.x + 15)
                    _direction = 1;
                else if (touch.position.x < _startPosition.x - 15)
                    _direction = -1;
                OnMoved.Invoke(_direction);
            }
            else
            {
                _startPosition = touch.position;
                _direction = 0;
            }
        }
    }
}

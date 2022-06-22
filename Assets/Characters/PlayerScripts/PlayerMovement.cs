using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField, Range(0, 30)] private float _speed;

    private Rigidbody2D _rigidbody;
    private float _direction;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input.OnMoved += SetDirection;
    }
    private void OnDestroy()
    {
        _input.OnMoved -= SetDirection;
    }
    private void SetDirection(float direction)
    {
        _direction = direction;
    }
    private void FixedUpdate()
    {
        float positionX = _rigidbody.position.x + _direction * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(new Vector2(positionX, _rigidbody.position.y));
    }
}
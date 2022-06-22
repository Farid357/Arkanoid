using System;
using UnityEngine;

public sealed class BallCollision : MonoBehaviour
{
    public static event Action OnEnter;
    [SerializeField] private BallMovement _ball;
    private float _lastPositionX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnEnter?.Invoke();
        float ballPositionX = transform.position.x;
        _lastPositionX = _ball.LastPositionX;

        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            if (ballPositionX < _lastPositionX + 0.1f && ballPositionX > _lastPositionX - 0.1f)
            {
                float collsionPointX = collision.contacts[0].point.x;
                float playerCenterPosition = player.transform.position.x;
                float difference = playerCenterPosition - collsionPointX;
                float direction = collsionPointX < playerCenterPosition ? -1 : 1;
                _ball.Jump(difference, direction);
            }
        }
        if(collision.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(1);
        }
        if (collision.gameObject.TryGetComponent(out UndestrictibleBlockEffect undestrictibleBlock))
        {
            undestrictibleBlock.Play();
        }
        _lastPositionX = ballPositionX;
    }
}

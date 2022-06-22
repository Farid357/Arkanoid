using UnityEngine;

public sealed class DeadZone : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BallMovement ballMovement))
            Destroy(collision.gameObject);
    }
}

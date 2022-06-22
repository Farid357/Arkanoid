using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public sealed class BallMovement : MonoBehaviour
{
    public float LastPositionX { get; private set; }
    private Rigidbody2D _rigidbody;

    private const int Force = 300;
    private bool _canMove = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space) && _canMove)
            Jump();
#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0 && _canMove)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.tapCount > 1)
            {
                Jump();
            }
        }
#endif
    }
    public void Jump(float differnce = 0, float direction = 1)
    {
        LastPositionX = transform.position.x;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;

        if (differnce == 0)
        {
            _rigidbody.AddForce(Vector2.up * Force, ForceMode2D.Force);
        }
        else
        {
            _rigidbody.AddForce(new Vector2(direction * Mathf.Abs(differnce * (Force / 2)), Force), ForceMode2D.Force);
        }
        _canMove = false;
    }
}

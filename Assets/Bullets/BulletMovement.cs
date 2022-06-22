using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public sealed class BulletMovement : MonoBehaviour
{
    [SerializeField, Range(2f, 20f)] private float _speed = 6f;
    private const int Damage = 1;
    private const float YMaxPosision = 8.6f;

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        TryDisable();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamagable damagable))
            damagable.TakeDamage(Damage);
    }
    private void TryDisable()
    {
        if (transform.position.y >= YMaxPosision)
            gameObject.SetActive(false);
    }
}

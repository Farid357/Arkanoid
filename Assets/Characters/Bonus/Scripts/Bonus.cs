using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider2D), typeof(BonusSound), typeof(SpriteRenderer))]
public abstract class Bonus : MonoBehaviour
{
    public event Action OnApplyed;
   
    [SerializeField, Range(1, 40)] protected int Speed = 5;
    [SerializeField, Range(0.3f, 120f)] protected float WaitTime = 2f;
    
    private SpriteRenderer _spriteRenderer;
    private Sprite _sprite;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _sprite = _spriteRenderer.sprite;
    }
   
    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * Speed * Time.fixedDeltaTime);

        if (transform.position.y < -12)
            Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            OnApplyed.Invoke();
            Apply();
            _spriteRenderer.sprite = null;
            Invoke(nameof(Disable) ,4f);
        }
    }
    protected abstract void Apply();

    private void Disable()
    {
        _spriteRenderer.sprite = _sprite;
        gameObject.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.UI;

public sealed class AudioButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private Color _onColor;
    [SerializeField] private Color _offColor;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    private bool _isEnable;

    public void SetState(bool value)
    {
        _isEnable = value;
        SetChange();
    }
    public void Change()
    {
        _isEnable = !_isEnable;
        SetChange();
    }
    private void SetChange()
    {
         _button.image.color = _isEnable ? _onColor : _offColor;
        _spriteRenderer.sprite = _isEnable ? _onSprite : _offSprite;
    }
}

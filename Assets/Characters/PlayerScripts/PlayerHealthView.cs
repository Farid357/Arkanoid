using TMPro;
using UnityEngine;

public sealed class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnEnable()
    {
        _playerHealth.OnChanged += Display;
    }
    private void OnDisable()
    {
        _playerHealth.OnChanged -= Display;
    }
    private void Display()
    {
        _healthText.text = _playerHealth.Health.ToString();
    }
}

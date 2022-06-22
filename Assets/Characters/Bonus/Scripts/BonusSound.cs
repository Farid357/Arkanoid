using UnityEngine;

public sealed class BonusSound : MonoBehaviour
{
    [SerializeField] private AudioSource _recieveSound;
    private Bonus _bonus;
    private AudioData _data = new();

    private void OnEnable()
    {
        _bonus = GetComponent<Bonus>();
        _bonus.OnApplyed += PlaySound;
    }
    private void OnDisable()
    {
        _bonus.OnApplyed -= PlaySound;
    }
    private void PlaySound()
    {
        var values = _data.Load();
        if (values.SoundOn)
        {
            _recieveSound.Play();
        }
    }
}

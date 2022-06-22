using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public sealed class UndestrictibleBlockEffect : MonoBehaviour
{
    private ParticleSystem _particle;

    private void Start()
    {
        _particle = GetComponent<ParticleSystem>();
    }
    public void Play()
    {
        _particle.Play();
    }
}

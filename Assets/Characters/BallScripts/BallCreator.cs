using UnityEngine;

public sealed class BallCreator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private BallMovement _ballPrefab;

    private const float Offset = 2.5f;

    private void Start()
    {
        BallCount.OnEnded += Create;
        Create();
    }
    private void OnDisable()
    {
        BallCount.OnEnded -= Create;
    }

    private void Create()
    {
        if (_player != null)
        {
            var position = new Vector2(_player.position.x, _player.position.y + Offset);
            Instantiate(_ballPrefab, position, Quaternion.identity);
        }
    }
}

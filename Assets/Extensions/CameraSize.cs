using UnityEngine;

public sealed class CameraSize : MonoBehaviour
{
    [SerializeField] private bool _isHorizontal = true;
    private Camera _camera;

    private const float SizeX = 1920.0f;
    private const float SizeY = 1080.0f;
    private float _targetSizeX = 0f;
    private float _targetSizeY = 0f;
    private const float HalfSize = 200.0f; // половина высоты в пикселях

    private void Awake()
    {
        _camera = Camera.main;
        _targetSizeX = _isHorizontal ? SizeX : SizeY;
        _targetSizeY = _isHorizontal ? SizeY : SizeX;

        Calculate();
    }
    private void Calculate()
    {
        float screenRatio = Screen.width / (float)Screen.height;
        float targetRatio = _targetSizeX / _targetSizeY;

        if (screenRatio >= targetRatio)
        {
            Resize();
        }
        else
        {
            float differentSize = targetRatio / screenRatio;
            Resize(differentSize);
        }
    }

    private void Resize(float differentSize = 1.0f)
    {
        _camera.orthographicSize = _targetSizeY / HalfSize * differentSize;
    }
}
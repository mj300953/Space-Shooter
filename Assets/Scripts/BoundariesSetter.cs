using UnityEngine;

public class BoundariesSetter : MonoBehaviour
{
    [SerializeField] private Transform leftBoundary;
    [SerializeField] private Transform rightBoundary;
    [SerializeField] private Transform upperBoundary;
    [SerializeField] private Transform lowerBoundary;

    private Camera _camera;
    
    private Vector2 _leftDownCameraCorner;
    private Vector2 _rightUpCameraCorner;
    private float _boxColliderHeight;
    private float _boxColliderWidth;
    
    private const float BorderWidth = 1f;
    
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        GetSetupValues();
        SetupScale();
        SetupPositions();
    }

    private void GetSetupValues()
    {
        _leftDownCameraCorner = _camera.ViewportToWorldPoint(new Vector2(0f, 0f));
        _rightUpCameraCorner = _camera.ViewportToWorldPoint(new Vector2(1f, 1f));
        _boxColliderHeight = _rightUpCameraCorner.y - _leftDownCameraCorner.y;
        _boxColliderWidth = _rightUpCameraCorner.x - _leftDownCameraCorner.x;
    }

    private void SetupScale()
    {
        leftBoundary.localScale = new Vector3(BorderWidth, _boxColliderHeight, 0);
        rightBoundary.localScale = new Vector3(BorderWidth, _boxColliderHeight, 0);
        lowerBoundary.localScale = new Vector3(_boxColliderWidth, BorderWidth, 0);
        upperBoundary.localScale = new Vector3(_boxColliderWidth, BorderWidth, 0);
    }

    private void SetupPositions()
    {
        leftBoundary.position = new Vector3(_leftDownCameraCorner.x - BorderWidth / 2, 0, 0);
        lowerBoundary.position = new Vector3(0, _leftDownCameraCorner.y - BorderWidth / 2, 0);
        rightBoundary.position = new Vector3(_rightUpCameraCorner.x + BorderWidth / 2, 0, 0);
        upperBoundary.position = new Vector3(0, _rightUpCameraCorner.y + BorderWidth / 2, 0);
    }
}

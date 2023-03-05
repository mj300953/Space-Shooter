using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float loopPosition;
    
    private Transform _transform;
    private Camera _camera;

    private Vector3 _startPosition;
    private Vector2 _leftDownCameraCorner;
    private Vector2 _rightUpCameraCorner;

    private float _backgroundScale;
    
    private const float StartingScale = 0.13384f;

    private void Awake()
    {
        _startPosition = transform.position;
        _transform = transform;
        _camera = Camera.main;
    }
    
    private void Start()
    {
        _leftDownCameraCorner = _camera.ViewportToWorldPoint(new Vector2(0f, 0f));
        _rightUpCameraCorner = _camera.ViewportToWorldPoint(new Vector2(1f, 1f));
        _backgroundScale = _rightUpCameraCorner.x - _leftDownCameraCorner.x;
        _transform.localScale = new Vector3(_backgroundScale, _backgroundScale, 0);
        loopPosition = loopPosition * StartingScale * _backgroundScale;
    }
    
    private void Update()
    {
        _transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        if (_transform.position.y < loopPosition)
        {
            _transform.position = _startPosition;
        }
    }
}

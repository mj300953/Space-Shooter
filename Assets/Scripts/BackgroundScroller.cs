using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float loopPosition;

    private Vector3 _startPosition;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _startPosition = _transform.position;
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

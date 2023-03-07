using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float loopPosition;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }
    
    private void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        if (transform.position.y < loopPosition)
        {
            transform.position = _startPosition;
        }
    }
}

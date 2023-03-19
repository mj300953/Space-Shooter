using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }
    
    private void Update()
    {
        _transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
    }
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float shotPower;
    [SerializeField] private Vector2 shotDirection;
    
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    public void Shot()
    {
        shotDirection = Vector2.ClampMagnitude(shotDirection, 1f);
        _rigidbody2D.AddForce(shotPower * shotDirection);
    }
}

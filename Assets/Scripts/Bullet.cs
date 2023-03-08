using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector2 shotVector;
    [SerializeField] private float shotPower;
    
    private Rigidbody2D _rigidbody2D;
	private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    public void Shot()
    {
        _rigidbody2D.AddForce(shotPower * shotVector);
    }
}

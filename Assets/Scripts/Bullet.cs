using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector2 shotVector;
    [SerializeField] private float shotPower;
    
    private Rigidbody2D _rigidbody2D;
	private SpriteRenderer _spriteRenderer;

	private int _protectedLayer;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _protectedLayer = LayerMask.NameToLayer("Protected");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		_spriteRenderer.enabled = false;
		gameObject.layer = _protectedLayer;
        Destroy(gameObject, 0.2f);
    }

    public void Shot()
    {
        _rigidbody2D.AddForce(shotPower * shotVector);
    }
}
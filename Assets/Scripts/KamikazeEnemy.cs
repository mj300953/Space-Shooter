using UnityEngine;

public class KamikazeEnemy : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private Vector2 targetDirection;
	private Rigidbody2D _rigidbody;
	
	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	private void Update()
	{
		targetDirection = Vector2.ClampMagnitude(targetDirection, 1f);
		_rigidbody.velocity = moveSpeed * targetDirection;
	}
}
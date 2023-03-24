using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
	
	[SerializeField] private Vector2 targetDirection;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotateSpeed;
	
	private Rigidbody2D _rigidbody2D;
	
	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	private void Update()
	{
		targetDirection = Vector2.ClampMagnitude(targetDirection, 1f);
		float rotateAmount = Vector3.Cross(targetDirection, -transform.up).z;

		_rigidbody2D.angularVelocity = -rotateAmount * rotateSpeed;
		_rigidbody2D.velocity = moveSpeed * targetDirection;
	}
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TargetedBullet : MonoBehaviour
{
    [SerializeField] private float shotPower;
    [SerializeField] private string targetType;
 
    private Transform _target;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag(targetType).transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    public void Shot()
    {
        Vector2 targetDirection = (Vector2)_target.position - _rigidbody2D.position;
        _rigidbody2D.AddForce(shotPower * targetDirection);
    }
}
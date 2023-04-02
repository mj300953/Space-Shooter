using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
   [SerializeField] private float speed;
   [SerializeField] private float rotateSpeed;
   [SerializeField] private string targetType;
   [SerializeField] private float soundTime;

   private Rigidbody2D _rigidbody2D;
   private Transform _transform;
   private Transform _target;
   private SpriteRenderer _spriteRenderer;

   private int _protectedLayer;
   
   private void Awake()
   {
      _rigidbody2D = GetComponent<Rigidbody2D>();
      _transform = transform;
      _target = GameObject.FindGameObjectWithTag(targetType).transform;
      _spriteRenderer = GetComponent<SpriteRenderer>();
      _protectedLayer = LayerMask.NameToLayer("Protected");
   }

   private void Update()
   {
      Vector2 targetDirection = (Vector2)_target.position - _rigidbody2D.position;

      targetDirection = Vector2.ClampMagnitude(targetDirection, 1f);
      
      float rotateAmount = Vector3.Cross(targetDirection, -_transform.up).z;

      _rigidbody2D.angularVelocity = -rotateAmount * rotateSpeed;
      _rigidbody2D.velocity = -_transform.up * speed;
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("Player"))
      {
         gameObject.layer = _protectedLayer;
         _spriteRenderer.enabled = false;
         Destroy(gameObject, soundTime);
      }
   }
}

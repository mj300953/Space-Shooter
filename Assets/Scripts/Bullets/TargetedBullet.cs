 using UnityEngine;

 namespace Bullets
 {
     [RequireComponent(typeof(Rigidbody2D))]
     public class TargetedBullet : Bullets
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
         
         protected override void BulletShot()
         {
             Vector2 targetDirection = (Vector2)_target.position - _rigidbody2D.position;
             targetDirection = Vector2.ClampMagnitude(targetDirection, 1f);
             _rigidbody2D.AddForce(shotPower * targetDirection);
         }
     }
 }
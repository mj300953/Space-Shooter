using UnityEngine;

namespace Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : Bullets
    {
        [SerializeField] private Vector2 shotVector;
        [SerializeField] private float shotPower;
        
        private Rigidbody2D _rigidbody2D;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected override void BulletShot()
        {
            _rigidbody2D.AddForce(shotPower * shotVector);
        }
    }
}
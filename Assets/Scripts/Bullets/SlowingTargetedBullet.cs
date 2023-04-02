using UnityEngine;
using System.Collections;

namespace Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SlowingTargetedBullet : Bullets
    {
        [SerializeField] private float shotPower;
        [SerializeField] private float slowDownTime;
        [SerializeField] private float slowDownValue;
        [SerializeField] private string targetType;
 
        private Transform _target;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _targetDirection;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _target = GameObject.FindGameObjectWithTag(targetType).transform;
        }

        private void Start()
        {
            _targetDirection = (Vector2)_target.position - _rigidbody2D.position;
            _targetDirection = Vector2.ClampMagnitude(_targetDirection, 1f);
        }

        private void Update()
        {
            _rigidbody2D.velocity = shotPower * _targetDirection;
        }
        
        protected override void BulletShot()
        {
            StartCoroutine(SlowDown(slowDownTime));
        }
    
        private IEnumerator SlowDown(float time)
        {
            yield return new WaitForSeconds(time);
            shotPower -= slowDownValue;
        }
    }
}
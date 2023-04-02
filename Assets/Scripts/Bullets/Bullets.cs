using UnityEngine;

namespace Bullets
{
    public abstract class Bullets : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private int _protectedLayer;

        private void Start()
        {
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
            BulletShot();
        }

        protected abstract void BulletShot();
    }
}
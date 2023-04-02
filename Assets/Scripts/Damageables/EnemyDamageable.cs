using UnityEngine;

namespace Damageables
{
    public class EnemyDamageable : Damageable
    {
        [SerializeField] private AudioSource destroyedSoundEffect;
        [SerializeField] private Explosion explosionPrefab;
        [SerializeField] private GameObject pickupPrefab;
        [SerializeField] private EnemyHealthBarBehaviour healthBar;
        [SerializeField] private float soundTime;
        
        private Transform _transform;
        private SpriteRenderer _spriteRenderer;

        public static int KilledEnemyCount { get; private set; }

        private int _protectedLayer;
        
        private void Awake()
        {
            _transform = transform;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _protectedLayer = LayerMask.NameToLayer("Protected");
        }
        
        protected override void HandleHealthBar()
        {
            healthBar.SetHealth(CurrentHealth, maxHealth);
        }

        protected override void HandleDeath()
        {
            if (CurrentHealth <= 0)
            {
                KilledEnemyCount++;
                gameObject.layer = _protectedLayer;
                Instantiate(explosionPrefab, _transform.position, _transform.rotation);
                Instantiate(pickupPrefab, _transform.position, Quaternion.identity);
                destroyedSoundEffect.Play();
                _spriteRenderer.enabled = false;
                Destroy(gameObject, soundTime);
            }
        }
    }
}
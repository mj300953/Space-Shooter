using UnityEngine;
using System.Collections;

namespace Damageables
{
    public abstract class Damageable : MonoBehaviour
    {
        [SerializeField] protected int maxHealth;
        [SerializeField] private AudioSource destroyedSoundEffect;
        [SerializeField] private AudioSource hitSoundEffect;
        [SerializeField] private Transform respawnPosition;
        [SerializeField] private Explosion explosionPrefab;
        [SerializeField] private float damageableAfterDeathTime;
        [SerializeField] private float spawnAfterDeathTime;
        [SerializeField] private int livesAmount;
        
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;
        private Transform _transform;
        
        protected int CurrentHealth;
        
        private int _protectedLayer;
        private int _defaultLayer;
        private int _currentLife;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
            CurrentHealth = maxHealth;
            _currentLife = livesAmount;
            _transform = transform;
            _protectedLayer = LayerMask.NameToLayer("Protected");
            _defaultLayer = LayerMask.NameToLayer("Default");
            HandleHealthBar();
        }

        private void Update()
        {
            HandleHealthBar();
        }

        public void TakeDamage(int amount)
        {
            hitSoundEffect.Play();
            CurrentHealth -= amount;
            
            if (CurrentHealth <= 0)
            {
                Instantiate(explosionPrefab, _transform.position, _transform.rotation);
                destroyedSoundEffect.Play();
                _spriteRenderer.enabled = false;
                _currentLife -= 1;
                gameObject.layer = _protectedLayer;
            }

            if (CurrentHealth <= 0 && _currentLife == 0)
            {
                Instantiate(explosionPrefab, _transform.position, _transform.rotation);
                destroyedSoundEffect.Play();
                Destroy(gameObject);
            }

            if (CurrentHealth <=0 && _currentLife > 0)
            {
                StartCoroutine(Respawn(spawnAfterDeathTime, damageableAfterDeathTime));
            }
        }
        
        private IEnumerator Respawn(float spawnInterval, float damageableInterval)
        {
            yield return new WaitForSeconds(spawnInterval);
            _transform.position = respawnPosition.position;
            _rigidbody.velocity = new Vector2(0, 0);
            _spriteRenderer.enabled = true;
            CurrentHealth = maxHealth;
            yield return new WaitForSeconds(damageableInterval);
            gameObject.layer = _defaultLayer;
        }
        
        protected abstract void HandleHealthBar();
    }
}
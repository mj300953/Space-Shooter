using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Damageables
{
    public class PlayerDamageable : Damageable
    {
        [SerializeField] private AudioSource destroyedSoundEffect;
        [SerializeField] private Transform respawnPosition;
        [SerializeField] private Explosion explosionPrefab;
        [SerializeField] private StaticHealthBarBehaviour healthBar;
        [SerializeField] private Image heart1;
        [SerializeField] private Image heart2;
        [SerializeField] private float damageableAfterDeathTime;
        [SerializeField] private float spawnAfterDeathTime;
        [SerializeField] private int livesAmount;
        
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private Transform _transform;

		public bool Died = false;

        private int _protectedLayer;
        private int _defaultLayer;
        private int _currentLife;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _currentLife = livesAmount;
            _transform = transform;
            _protectedLayer = LayerMask.NameToLayer("Protected");
            _defaultLayer = LayerMask.NameToLayer("Default");
            HandleHealthBar();
        }

        private void Update()
        {
            heart1.gameObject.SetActive(_currentLife >= 1);
            heart2.gameObject.SetActive(_currentLife == 2);
        }
        
        protected override void HandleDeath()
        {
            if (CurrentHealth <= 0)
            {
				Died = true;
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
        
        protected override void HandleHealthBar()
        {
            healthBar.SetHealth(CurrentHealth, maxHealth);
        }
        
        private IEnumerator Respawn(float spawnInterval, float damageableInterval)
        {
            yield return new WaitForSeconds(spawnInterval);
            _transform.position = respawnPosition.position;
            _rigidbody2D.velocity = new Vector2(0, 0);
            _spriteRenderer.enabled = true;
            CurrentHealth = maxHealth;
            HandleHealthBar();
            yield return new WaitForSeconds(damageableInterval);
            gameObject.layer = _defaultLayer;
        }
    }
}
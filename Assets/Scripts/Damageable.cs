using System.Collections;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private AudioSource hitSoundEffect;
    [SerializeField] private int maxHealth;
    [SerializeField] private int livesAmount;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Transform _transform;
    private Vector2 _startPosition;
    
    private int _currentHealth;
    private int _currentLife;
    private int _protectedLayer;
    private int _defaultLayer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentHealth = maxHealth;
        _currentLife = livesAmount;
        _transform = transform;
        _startPosition = _transform.position;
        _protectedLayer = LayerMask.NameToLayer("Protected");
        _defaultLayer = LayerMask.NameToLayer("Default");
    }

    public void TakeDamage(int amount)
    {
        hitSoundEffect.Play();
        _currentHealth -= amount;
        
        if (_currentHealth <= 0)
        {
            _spriteRenderer.enabled = false;
            _currentLife -= 1;
            gameObject.layer = _protectedLayer;
        }
        
        if (_currentHealth <=0 && _currentLife > 0)
        {
            StartCoroutine(Respawn(1f));
        }

        if (_currentHealth <= 0 && _currentLife == 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        _transform.position = _startPosition;
        _rigidbody.velocity = new Vector2(0, 0);
        _spriteRenderer.enabled = true;
        yield return new WaitForSeconds(1f);
        gameObject.layer = _defaultLayer;
    }
}
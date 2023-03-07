using System.Collections;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private AudioSource hitSoundEffect;
    [SerializeField] private int maxHealth;
    [SerializeField] private int livesAmount;

    private SpriteRenderer _spriteRenderer;
    private Vector2 _startPosition;
    
    private int _currentHealth;
    private int _currentLife;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentHealth = maxHealth;
        _currentLife = livesAmount;
        _startPosition = transform.position;
    }

    public void TakeDamage(int amount)
    {
        hitSoundEffect.Play();
        _currentHealth -= amount;
        
        if (_currentHealth <= 0)
        {
            transform.localScale = new Vector3(0, 0, 0);
            _spriteRenderer.enabled = false;
            _currentLife -= 1;
        }
        
        if (_currentHealth <=0 && _currentLife > 0)
        {
            StartCoroutine(Respawn(0.5f));
        }

        if (_currentHealth <= 0 && _currentLife == 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.position = _startPosition;
        _spriteRenderer.enabled = true;
    }
}
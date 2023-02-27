using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
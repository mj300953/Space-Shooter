using UnityEngine;

public class DealDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private string damageableTag;
    [SerializeField] private int damageAmount;

    private Damageable _damageable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(damageableTag) && other.TryGetComponent(out _damageable))
        {
            _damageable.TakeDamage(damageAmount);
        }
    }
}

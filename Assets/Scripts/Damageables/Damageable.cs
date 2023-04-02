using UnityEngine;

namespace Damageables
{
    public abstract class Damageable : MonoBehaviour
    {
        [SerializeField] private AudioSource hitSoundEffect;
        [SerializeField] protected int maxHealth;
        
        protected int CurrentHealth;
        
        private void Start()
        {
            CurrentHealth = maxHealth;
            HandleHealthBar();
        }

        public void TakeDamage(int amount)
        {
            hitSoundEffect.Play();
            CurrentHealth -= amount;
            HandleHealthBar();
            HandleDeath();
        }
        
        protected abstract void HandleHealthBar();
        protected abstract void HandleDeath();
    }
}
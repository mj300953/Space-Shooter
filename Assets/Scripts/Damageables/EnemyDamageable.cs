using UnityEngine;

namespace Damageables
{
    public class EnemyDamageable : Damageable
    {
        [SerializeField] private EnemyHealthBarBehaviour healthBar;
      
        protected override void HandleHealthBar()
        {
            healthBar.SetHealth(CurrentHealth, maxHealth);
        }
    }
}
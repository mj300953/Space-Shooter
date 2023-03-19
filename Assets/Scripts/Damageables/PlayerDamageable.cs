using UnityEngine;

namespace Damageables
{
    public class PlayerDamageable : Damageable
    {
        [SerializeField] private StaticHealthBarBehaviour healthBar;

        protected override void HandleHealthBar()
        {
            healthBar.SetHealth(CurrentHealth, maxHealth);
        }
    }
}
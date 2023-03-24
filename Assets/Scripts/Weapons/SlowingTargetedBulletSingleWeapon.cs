using UnityEngine;

namespace Weapons
{
    public class SlowingTargetedBulletSingleWeapon:BaseWeapon
    {
    
        [SerializeField] private SlowingTargetedBullet bulletPrefab; 
        [SerializeField] private Transform shotPoint;
        
        protected override void Shot() 
        {
            SlowingTargetedBullet bullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity); 
            bullet.Shot();
        }
    }
}
using UnityEngine;

namespace Weapons
{
    public class TargetedSingleWeapon : BaseWeapon
    {
        [SerializeField] private TargetedBullet bulletPrefab;
        [SerializeField] private Transform shotPoint;

        protected override void Shot()
        {
            TargetedBullet bullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
            bullet.Shot();
        }
    }
}
using UnityEngine;

namespace Weapons
{
    public class SingleWeapon : BaseWeapon
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform shotPoint;

        protected override void Shot()
        {
            Bullet bullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
            bullet.Shot();
        }
    }
}
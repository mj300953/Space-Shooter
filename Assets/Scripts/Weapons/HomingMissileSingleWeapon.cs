using UnityEngine;

namespace Weapons
{
    public class HomingMissileSingleWeapon : BaseWeapon
    {
        [SerializeField] private HomingMissile bulletPrefab;
        [SerializeField] private Transform shotPoint;

        protected override void Shot()
        {
            HomingMissile bullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
        }
    }
}
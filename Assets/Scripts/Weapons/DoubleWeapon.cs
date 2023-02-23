using UnityEngine;

namespace Weapons
{
    public class DoubleWeapon : BaseWeapon
    {
        [SerializeField] private Transform shotPoint1;
        [SerializeField] private Transform shotPoint2;
        [SerializeField] private Bullet bulletPrefab;

        protected override void Shot()
        {
            Shot(shotPoint1.position);
            Shot(shotPoint2.position);
        }

        private void Shot(Vector3 position)
        {
            Bullet bullet2 = Instantiate(bulletPrefab, position, Quaternion.identity);
            bullet2.Shot();
        }
    }
}
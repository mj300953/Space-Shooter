using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    public class DoubleWeapon : BaseWeapon
    {
        [SerializeField] private Transform shotPoint1;
        [SerializeField] private Transform shotPoint2;
        [FormerlySerializedAs("bulletPrefab")] [SerializeField] private Bullets.Bullets bulletsPrefab;

        protected override void Shot()
        {
            Shot(shotPoint1.position);
            Shot(shotPoint2.position);
        }

        private void Shot(Vector3 position)
        {
            Bullets.Bullets bullet2 = Instantiate(bulletsPrefab, position, Quaternion.identity);
            bullet2.Shot();
        }
    }
}
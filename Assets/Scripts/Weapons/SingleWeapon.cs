using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    public class SingleWeapon : BaseWeapon
    {
        [SerializeField] private Bullets.Bullets bulletsPrefab;
        [SerializeField] private Transform shotPoint;

        protected override void Shot()
        {
            Bullets.Bullets bullets = Instantiate(bulletsPrefab, shotPoint.position, Quaternion.identity);
            bullets.Shot();
        }
    }
}
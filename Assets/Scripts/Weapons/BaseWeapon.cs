using UnityEngine;

namespace Weapons
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        [SerializeField] private float shotInterval;
        
        private float _shotFinishTime;
        
        public void TryShooting()
        {
            if (!ShotIntervalPassed())
            {
                return;
            }

            MarkShotInterval();
            Shot();
        }

        protected abstract void Shot();

        private bool ShotIntervalPassed()
        {
            return Time.time >= _shotFinishTime;
        }

        private void MarkShotInterval()
        {
            _shotFinishTime = Time.time + shotInterval;
        }
    }
}
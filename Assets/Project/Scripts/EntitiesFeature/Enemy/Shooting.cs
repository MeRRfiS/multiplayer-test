using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Enemy
{
    public class Shooting
    {
        private float _projectileSpeed = 10f;
        private Transform _shootOrigin;
        private Projectile _projectilePrefab;

        public Shooting(Projectile projectilePrefab, Transform shootOrigin)
        {
            _projectilePrefab = projectilePrefab;
            _shootOrigin = shootOrigin;
        }

        public void Shoot(Vector3 direction)
        {
            Projectile projectile = MonoBehaviour.Instantiate(_projectilePrefab);
            
            projectile.transform.position = _shootOrigin.position;
            projectile.GetComponent<Rigidbody>().linearVelocity = direction.normalized * _projectileSpeed;
            projectile.NetworkObject.Spawn();
        }
    }
}

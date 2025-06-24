using MultiplayerTest.Scripts.EntitiesFeature.Interfaces;
using System.Collections;
using Unity.Netcode;
using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Enemy
{
    public class EnemyEntity : NetworkBehaviour
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private LayerMask _playerMask;
        [SerializeField] private Projectile _projectilePrefab;

        private Coroutine _shootingCoroutine;
        private PlayerFinder _playerFinder;
        private Shooting _shooting;
        private IEntityRotation _rotation;

        private void Start()
        {
            _shooting = new Shooting(_projectilePrefab, transform);
            _playerFinder = new PlayerFinder(transform, _playerMask);
            _rotation = new EnemyRotate(transform);

            if(!IsHost) return;
            _shootingCoroutine = StartCoroutine(Shooting());
        }

        private void Update()
        {
            if (!IsHost) return;

            Transform closestPlayer = _playerFinder.FindClosestPlayer();
            if (closestPlayer != null)
            {
                _rotation.SetLook(closestPlayer.position);
                _rotation.Rotate();
            }
        }

        public override void OnDestroy()
        {
            if(_shootingCoroutine != null)
            {
                StopCoroutine(_shootingCoroutine);
                _shootingCoroutine = null;
            }
        }

        private IEnumerator Shooting()
        {
            while (true)
            {
                yield return new WaitForSeconds(_enemyConfig.ShootInterval);
                _shooting.Shoot(transform.forward);
            }
        }
    }
}
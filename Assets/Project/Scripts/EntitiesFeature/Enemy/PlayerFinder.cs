using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Enemy
{
    public class PlayerFinder
    {
        private Transform _enemyTransform;
        private LayerMask _playerMask;

        public PlayerFinder(Transform enemyTransform, LayerMask playerMask)
        {
            _enemyTransform = enemyTransform;
            _playerMask = playerMask;
        }

        public Transform FindClosestPlayer()
        {
            Transform closestPlayer = null;
            float minDistance = Mathf.Infinity;

            Collider[] hits = Physics.OverlapSphere(_enemyTransform.position, 100f, _playerMask);

            foreach (var hit in hits)
            {
                float distance = Vector3.Distance(_enemyTransform.position, hit.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestPlayer = hit.transform;
                }
            }

            return closestPlayer;
        }
    }
}

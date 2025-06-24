using System.Collections;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace MultiplayerTest.Scripts.EntitiesFeature.Enemy
{
    public class EnemiesSpawner : NetworkBehaviour
    {
        [SerializeField] private float _spawnTime;
        [SerializeField] private Vector3 _spawnAreaMin;
        [SerializeField] private Vector3 _spawnAreaMax;
        [SerializeField] private LayerMask _obstacleLayer;
        [SerializeField] private EnemyEntity _enemyPrefab;

        private const float CheckRadius = 0.5f;
        private Coroutine _spawnCoroutine;

        private void Start()
        {
            if (!IsHost) return;
            _spawnCoroutine = StartCoroutine(Spawn());
        }

        public override void OnDestroy()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnTime);

                for (int i = 0; i < 10; i++)
                {
                    Vector3 randomPos = new Vector3(
                    Random.Range(_spawnAreaMin.x, _spawnAreaMax.x),
                    _spawnAreaMin.y,
                    Random.Range(_spawnAreaMin.z, _spawnAreaMax.z));

                    bool overlaps = Physics.CheckSphere(randomPos, CheckRadius, _obstacleLayer);

                    if (!overlaps)
                    {
                        var enemy = Instantiate(_enemyPrefab);
                        enemy.transform.position = randomPos;
                        enemy.NetworkObject.Spawn();

                        break;
                    }
                }
            }
        }
    }
}
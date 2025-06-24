using MultiplayerTest.Scripts.EntitiesFeature.Player;
using Unity.Netcode;
using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Enemy
{
    public class Projectile : NetworkBehaviour
    {
        [SerializeField] private int _damage = 10;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerEntity player))
            {
                Despawn();
                return;
            }

            player.Damage(_damage);
            Despawn();
        }

        private void Despawn()
        {
            if (IsHost)
            {
                NetworkObject.Despawn();
                Destroy(gameObject);
            }
        }
    }
}

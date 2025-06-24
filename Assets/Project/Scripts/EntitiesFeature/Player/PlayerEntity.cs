using MultiplayerTest.Scripts.EntitiesFeature.Interfaces;
using System;
using Unity.Netcode;
using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Player
{
    public class PlayerEntity : NetworkBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _cameraPivot;
        private NetworkVariable<int> _health = new NetworkVariable<int>();

        private IEntityMovement _movement;
        private IEntityRotation _rotation;

        public override void OnNetworkSpawn()
        {
            if (!IsOwner)
            {
                _cameraPivot.gameObject.SetActive(false);
                enabled = false;
                return;
            }

            _movement = new PlayerMoving(_characterController, _playerConfig.MovingSpeed);
            _rotation = new PlayerRotate(transform, _cameraPivot, _playerConfig.Sensitivity);
            _health.Value = _playerConfig.InitialHealth;
        }

        private void Update()
        {
            if (!IsOwner) return;
            _movement.Move();
        }

        private void LateUpdate()
        {
            if (!IsOwner) return;
            _rotation.Rotate();
        }

        public void ApplyDirection(Vector3 direction)
        {
            if (!IsOwner) return;

            if (_movement == null)
            {
                Debug.LogError("Movement is not initialized.");
                return;
            }

            _movement.SetDirection(direction);
        }

        public void ApplyLook(Vector3 look)
        {
            if (!IsOwner) return;

            if (_rotation == null)
            {
                Debug.LogError("Rotation is not initialized.");
                return;
            }

            _rotation.SetLook(look);
        }

        public void Damage(int damage)
        {
            if (!IsOwner) return;

            _health.Value = Math.Max(0, _health.Value - damage);
        }
    }
}
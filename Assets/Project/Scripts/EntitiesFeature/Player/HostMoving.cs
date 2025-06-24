using MultiplayerTest.Scripts.EntitiesFeature.Interfaces;
using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Player
{
    public class HostMoving : IEntityMovement
    {
        private float _speed;
        private Vector3 _direction;
        private CharacterController _characterController;

        public HostMoving(CharacterController characterController, float speed)
        {
            _characterController = characterController;
            _speed = speed;
        }

        public void Move()
        {
            Vector3 worldDirection = _characterController.transform.TransformDirection(_direction);
            _characterController.Move(worldDirection * _speed * Time.deltaTime);
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction.normalized;
        }
    }
}
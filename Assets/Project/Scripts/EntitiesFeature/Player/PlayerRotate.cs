using MultiplayerTest.Scripts.EntitiesFeature.Interfaces;
using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Player
{
    public class PlayerRotate : IEntityRotation
    {
        private float _xRotation;
        private float _sensitivity;
        private Transform _playerBody;
        private Transform _cameraPivot;
        private Vector3 _look;

        private const float MinXRotation = -60f;
        private const float MaxXRotation = 75f;

        public PlayerRotate(Transform playerBody, Transform cameraPivot, float sensitivity)
        {
            _playerBody = playerBody;
            _cameraPivot = cameraPivot;
            _sensitivity = sensitivity;
        }

        public void Rotate()
        {
            _playerBody.Rotate(Vector3.up * _look.x * _sensitivity);

            _xRotation -= _look.y * _sensitivity;
            _xRotation = Mathf.Clamp(_xRotation, MinXRotation, MaxXRotation);

            _cameraPivot.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        }

        public void SetLook(Vector3 look)
        {
            _look = look;
        }
    }
}

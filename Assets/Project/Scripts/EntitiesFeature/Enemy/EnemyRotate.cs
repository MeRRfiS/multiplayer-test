using MultiplayerTest.Scripts.EntitiesFeature.Interfaces;
using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Enemy
{
    public class EnemyRotate : IEntityRotation
    {
        private Transform _transform;
        private Vector3 _look;

        public EnemyRotate(Transform transform)
        {
            _transform = transform;
        }

        public void Rotate()
        {
            Vector3 lookDir = (_look - _transform.position).normalized;
            lookDir.y = 0f;
            _transform.rotation = Quaternion.LookRotation(lookDir);
        }

        public void SetLook(Vector3 look)
        {
            _look = look;
        }
    }
}

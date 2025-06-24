using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Interfaces
{
    public interface IEntityMovement
    {
        public void SetDirection(Vector3 direction);
        public void Move();
    }
}
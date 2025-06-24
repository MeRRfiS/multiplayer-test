using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Interfaces
{
    public interface IEntityRotation
    {
        public void SetLook(Vector3 look);
        public void Rotate();
    }
}

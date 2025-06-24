using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Scriptable Objects/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public float MovingSpeed { get; private set; } = 5f;
        [field: SerializeField] public float Sensitivity { get; private set; } = 10f;
        [field: SerializeField] public int InitialHealth { get; private set; } = 100;
    }
}
using UnityEngine;

namespace MultiplayerTest.Scripts.EntitiesFeature.Enemy
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Scriptable Objects/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public float ShootInterval { get; set; } = 3f;
    }
}
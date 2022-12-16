using FeatureSystem.Features;
using FeatureSystem.Systems;
using GameFeatures.PlayerFeature.Components;
using GameFeatures.PlayerFeature.Systems;
using UnityEngine;

namespace GameFeatures.PlayerFeature
{
    [CreateAssetMenu(menuName = "Feature/Player Feature")]
    public class PlayerFeature : Feature
    {
        [SerializeField]
        private PlayerComponent _playerPrefab;

        [SerializeField]
        private Bounds _movingBounds;

        [SerializeField]
        private Vector3 _spawnPosition;

        [SerializeField]
        private float _movementSpeed = 5f;

        [SerializeField]
        private float _rotationSpeed = 1f;

        public override void Initialize()
        {
            GameSystems.RegisterSystem(new PlayerSpawnSystem(_playerPrefab, _spawnPosition));
            GameSystems.RegisterSystem(new PlayerInputSystem());
            GameSystems.RegisterSystem(new PlayerMovementSystem(_movingBounds, _movementSpeed, _rotationSpeed));
        }
    }
}

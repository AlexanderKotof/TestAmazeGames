using FeatureSystem.Systems;
using GameFeatures.PlayerFeature.Components;
using UnityEngine;

namespace GameFeatures.PlayerFeature.Systems
{
    public class PlayerSpawnSystem : ISystem
    {
        private PlayerComponent _playerPrefab;
        private Vector3 _spawnPosition;

        public PlayerComponent Player { get; private set; }

        public PlayerSpawnSystem(PlayerComponent playerPrefab, Vector3 spawnPosition)
        {
            _playerPrefab = playerPrefab;
            _spawnPosition = spawnPosition;
        }

        public void Destroy()
        {
            PlayerComponent.Destroy(Player);
        }

        public void Initialize()
        {
            Player = PlayerComponent.Instantiate(_playerPrefab, _spawnPosition, Quaternion.identity);
        }
    }
}

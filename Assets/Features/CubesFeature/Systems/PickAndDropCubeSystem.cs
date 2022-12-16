using FeatureSystem.Systems;
using GameFeatures.CubesFeature.Components;
using GameFeatures.PlayerFeature.Systems;
using UnityEngine;

namespace GameFeatures.CubesFeature.Systems
{
    public class PickAndDropCubeSystem : ISystem, ISystemUpdate
    {
        private readonly DropPointComponent _dropPointPrefab;
        private readonly Vector3 _dropPointPosition;
        private readonly float _collectDistance;
        private readonly float _dropDistance;

        private CubeSpawnSystem _cubeSpawnSystem;
        private PlayerSpawnSystem _playerSpawnSystem;

        private bool _cubePicked;

        public PickAndDropCubeSystem(DropPointComponent dropPointPrefab, Vector3 dropPointPosition, float collectDistance, float dropDistance)
        {
            _dropPointPrefab = dropPointPrefab;
            _dropPointPosition = dropPointPosition;
            _collectDistance = collectDistance;
            _dropDistance = dropDistance;
        }

        public void Initialize()
        {
            _cubeSpawnSystem = GameSystems.GetSystem<CubeSpawnSystem>();
            _playerSpawnSystem = GameSystems.GetSystem<PlayerSpawnSystem>();

            SpawnDropPoint();
        }

        private void SpawnDropPoint()
        {
            Object.Instantiate(_dropPointPrefab, _dropPointPosition, Quaternion.identity);
        }

        public void Destroy()
        {

        }

        public void Update()
        {
            var player = _playerSpawnSystem.Player;
            if (!_cubePicked)
            {
                for (int i = 0; i < _cubeSpawnSystem.Cubes.Count; i++)
                {
                    CubeComponent cube = _cubeSpawnSystem.Cubes[i];
                    var sqrDistance = (player.Position - cube.Position).sqrMagnitude;
                    if (sqrDistance > _collectDistance * _collectDistance)
                        continue;

                    _cubePicked = true;
                    _cubeSpawnSystem.DespawnCube(cube);
                    break;
                }
            }
            else
            {
                var dropPointSqrDistance = (player.Position - _dropPointPosition).sqrMagnitude;

                if (dropPointSqrDistance < _dropDistance * _dropDistance)
                {
                    // Drop Cube
                    _cubePicked = false;
                }
            }
        }
    }
}

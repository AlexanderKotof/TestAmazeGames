using FeatureSystem.Systems;
using GameFeatures.CubesFeature.Components;
using System.Collections.Generic;
using UnityEngine;

namespace GameFeatures.CubesFeature.Systems
{
    public class CubeSpawnSystem : ISystem, ISystemUpdate
    {
        private readonly CubeComponent _cubePrefab;
        private readonly Bounds _spawnBounds;
        private readonly float _spawnRate;
        private readonly int _maxCubesCount;
        private readonly int _preSpawnCount;

        private float _timer;

        public List<CubeComponent> Cubes { get; private set; }

        private const float _minDistanceToAnotherCube = 1f;

        public CubeSpawnSystem(CubeComponent cubePrefab, Bounds spawnBounds, float spawnRate, int preSpawnCount, int maxCubesCount)
        {
            _cubePrefab = cubePrefab;
            _spawnBounds = spawnBounds;
            _spawnRate = spawnRate;
            _maxCubesCount = maxCubesCount;
            _preSpawnCount = preSpawnCount;

            Cubes = new List<CubeComponent>();
            _timer = 0;
        }

        public void Destroy()
        {
            
        }

        public void Initialize()
        {
            for (int i = 0; i < _preSpawnCount; i++)
                SpawnCube();
        }

        public void Update()
        {
            _timer += Time.deltaTime;

            if (Cubes.Count >= _maxCubesCount)
                return;

            if (_timer < 1 / _spawnRate)
                return;

            SpawnCube();
            _timer = 0;
        }

        private void SpawnCube()
        {
            var position = CalculatePositionAndCheck();
            var rotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
            var cube = CubeComponent.Instantiate(_cubePrefab, position, rotation);
            Cubes.Add(cube);
        }

        private Vector3 CalculatePositionAndCheck()
        {
            var position = CalculateRandomPosition();
            var distanceChecked = false;

            while (!distanceChecked)
            {
                distanceChecked = true;
                foreach (var cube in Cubes)
                {
                    var sqrDistance = (cube.Position - position).sqrMagnitude;
                    if (sqrDistance < _minDistanceToAnotherCube * _minDistanceToAnotherCube)
                    {
                        position = CalculateRandomPosition();
                        distanceChecked = false;
                        break;
                    }
                }
            }

            return position;
        }

        private Vector3 CalculateRandomPosition()
        {
            var position = new Vector3(_spawnBounds.extents.x * 2 * Random.value,
                                       _spawnBounds.extents.y * 2 * Random.value,
                                       _spawnBounds.extents.z * 2 * Random.value);
            position += _spawnBounds.min;
            return position;
        }

        public void DespawnCube(CubeComponent cube)
        {
            Cubes.Remove(cube);
            CubeComponent.Destroy(cube.gameObject);
        }
    }
}

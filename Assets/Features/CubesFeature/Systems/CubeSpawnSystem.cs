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

            if (Cubes.Count > _maxCubesCount)
                return;

            if (_timer < 1 / _spawnRate)
                return;

            SpawnCube();
            _timer = 0;
        }

        private void SpawnCube()
        {
            var position = _spawnBounds.min + _spawnBounds.max * Random.value;
            var rotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
            var cube = CubeComponent.Instantiate(_cubePrefab, position, rotation);
            Cubes.Add(cube);
        }

        public void DespawnCube(CubeComponent cube)
        {
            Cubes.Remove(cube);
            CubeComponent.Destroy(cube);
        }
    }
}

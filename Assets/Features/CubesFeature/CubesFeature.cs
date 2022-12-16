using FeatureSystem.Features;
using FeatureSystem.Systems;
using GameFeatures.CubesFeature.Components;
using GameFeatures.CubesFeature.Systems;
using UnityEngine;

namespace GameFeatures.CubesFeature
{
    [CreateAssetMenu(menuName = "Feature/Cubes Feature")]
    public class CubesFeature : Feature
    {
        [SerializeField] private CubeComponent _cubePrefab;
        [SerializeField] private DropPointComponent _dropPointPrefab;

        [SerializeField] private Vector3 _dropPointPosition;

        [SerializeField] private Bounds _spawnBounds;

        [SerializeField] private int _preSpawnCount = 5;

        [SerializeField] private int _maxCubesCount = 10;

        [SerializeField] private float _spawnRate = 5f;

        [SerializeField] private float _collectDistance = 1f;

        [SerializeField] private float _dropDistance = 1f;

        public override void Initialize()
        {
            GameSystems.RegisterSystem(new CubeSpawnSystem(_cubePrefab, _spawnBounds, _spawnRate, _preSpawnCount, _maxCubesCount));
            GameSystems.RegisterSystem(new PickAndDropCubeSystem(_dropPointPrefab, _dropPointPosition, _collectDistance, _dropDistance));
        }
    }
}

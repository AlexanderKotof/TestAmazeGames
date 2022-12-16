using FeatureSystem.Features;
using FeatureSystem.Systems;
using System.Threading.Tasks;

namespace Core.StateMachine.States
{
    public class InitializeFeaturesState : GameState
    {
        private Feature[] _features;
        public InitializeFeaturesState(Feature[] features) : base(nameof(InitializeFeaturesState))
        {
            _features = features;
        }

        public override Task Execute()
        {
            InitializeFeatures();
            InitializeSystems();
            return Task.CompletedTask;
        }

        private void InitializeSystems()
        {
            foreach (var system in GameSystems.Systems.Values)
            {
                system.Initialize();
            }
        }

        private void InitializeFeatures()
        {
            foreach (var feature in _features)
            {
                feature.Initialize();
            }
        }
    }
}
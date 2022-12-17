using Core.StateMachine.States;
using FeatureSystem.Features;
using System.Threading.Tasks;

namespace Core.StateMachine
{
    public class AppStateMachine
    {
        public IGameState State => _currentState;

        private IGameState _currentState;

        private readonly GameState _loadedState = new GameState("Loaded");

        public async Task StartGame()
        {
            await SetState(new LoadGameScene());
            await SetState(new InitializeFeaturesState(Features.GetFeatures()));
            await SetState(_loadedState);
        }

        private async Task SetState(IGameState state)
        {
            _currentState = state;
            await _currentState.Execute();
        }
    }
}
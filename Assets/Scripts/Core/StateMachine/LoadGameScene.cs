using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Core.StateMachine.States
{
    public class LoadGameScene : GameState
    {
        private const string _gameSceneName = "Game";
        public LoadGameScene() : base(nameof(LoadGameScene))
        {
        }

        public override async Task Execute()
        {
            var result = SceneManager.LoadSceneAsync(_gameSceneName);

            while (!result.isDone)
            {
                await Task.Delay(100);
            }
        }
    }
}
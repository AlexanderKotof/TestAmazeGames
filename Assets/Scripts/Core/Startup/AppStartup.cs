using Core.StateMachine;
using ScreenSystem;
using UI.Screens;
using UnityEngine;

namespace Core.Startup
{
    public class AppStartup : MonoBehaviour
    {
        private AppStateMachine _stateMachine;

        private async void Start()
        {
            DontDestroyOnLoad(this);

            _stateMachine = new AppStateMachine();
            await _stateMachine.StartGame();

            ScreensManager.ShowScreen<ControlScreen>();
        }
    }
}

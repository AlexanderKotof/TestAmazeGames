using Core.StateMachine;
using UnityEngine;

namespace Core.Startup
{
    public class AppStartup : MonoBehaviour
    {
        private AppStateMachine _stateMachine;
        private void Start()
        {
            _stateMachine = new AppStateMachine();
            _stateMachine.StartGame();
        }
    }
}

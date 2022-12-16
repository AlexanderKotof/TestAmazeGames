using System.Threading.Tasks;

namespace Core.StateMachine.States
{
    public class GameState : IGameState
    {
        public string name;

        public GameState(string name)
        {
            this.name = name;
        }

        public virtual Task Execute()
        {
            return Task.CompletedTask;
        }
    }
}
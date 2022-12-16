using System.Threading.Tasks;

namespace Core.StateMachine.States
{
    public interface IGameState
    {
        public Task Execute();
    }
}
using Infrastructure.Services;

namespace Infrastructure.FSM
{
    public interface IFSMBuilder<TTrigger,TState> : IService where TState : IState
    {
        public void Entry(TTrigger trigger);
        public void Build(FSM<TTrigger,TState> fsm);
    }
}
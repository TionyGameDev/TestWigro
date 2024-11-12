using Infrastructure.FSM.Factory;
using Infrastructure.Loader;
using Infrastructure.Services;
using UI.Managers;

namespace Infrastructure.FSM.States
{
    public class BootstrapState : IState
    {
        private readonly ResourcesLoader _sceneLoader;
        private readonly AllServices _services;
        private readonly StartGameStateMachine _stateMachine;

        public BootstrapState(StartGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _services = AllServices.Container;

            RegistryServices();
        }

        private void RegistryServices()
        {
            _services.RegisterSingle(_stateMachine);
            _services.RegisterSingle<IAssetsProvider>(new ResourcesLoader());
            _services.RegisterSingle<IGameFactory> (new GameFactory(_services.Single<IAssetsProvider>()));

            SetManagers();
        }

        private void SetManagers() => UIManager.Instance.SetProvider(_services.Single<IAssetsProvider>());


        void IState.Enter()
        {
            _stateMachine.Entry(GameState.Load);
        }

        void IState.Exit()
        {
            //Debug.Log("ExitState - " + this);
        }
    }
}
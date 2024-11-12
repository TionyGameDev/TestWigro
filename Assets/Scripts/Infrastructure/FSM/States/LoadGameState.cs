using Infrastructure.FSM.Factory;
using Setting;
using Shop;

namespace Infrastructure.FSM.States
{
    public class LoadGameState : IState
    {
        private IGameFactory _gameFactory;
        private GameSettings _gameSettings;
        private StartGameStateMachine _stateMachine;
        private ShopItems _items;
        public LoadGameState(IGameFactory gameFactory, GameSettings gameSettings, StartGameStateMachine stateMachine, ShopItems items)
        {
            _gameFactory = gameFactory;
            _gameSettings = gameSettings;
            _stateMachine = stateMachine;
            _items = items;
        }

        public void Enter()
        {
            Init();
        }

        private async void Init()
        {
            await _gameFactory.LoadMainMenu(_gameSettings,_stateMachine,_items);
            _stateMachine.Entry(GameState.Game);
        }

        public void Exit()
        {
            
        }
    }
}
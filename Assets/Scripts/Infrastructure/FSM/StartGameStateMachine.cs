using System.Collections.Generic;
using Infrastructure.FSM.Factory;
using Infrastructure.FSM.States;
using Infrastructure.Services;
using Setting;
using Shop;

namespace Infrastructure.FSM
{
    public class StartGameStateMachine : IFSMBuilder<GameState,IState>
    {
        private AllServices _services;
        private GameSettings _gameSettings;
        private ShopItems _shopItems;
        private FSM<GameState, IState> _fsm;

        public StartGameStateMachine(AllServices services, GameSettings gameSettings,ShopItems shopItems)
        {
            _services = services;
            _gameSettings = gameSettings;
            _shopItems = shopItems;
        }

        public void Entry(GameState trigger) => _fsm.Enter(trigger);

        public void Build(FSM<GameState, IState> fsm)
        {
            _fsm = fsm;
            
            _fsm.SetConfiguration(new Dictionary<GameState, IState>
            {
                [GameState.Init] = new BootstrapState(this),
                [GameState.Load] = new LoadGameState(_services.Single<IGameFactory>(),_gameSettings,this,_shopItems),
                [GameState.Game] = new GameLoopState(),
                [GameState.Finish] = new FinishGameState(),
            });
        }
    }
}
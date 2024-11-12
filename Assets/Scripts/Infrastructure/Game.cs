using Infrastructure;
using Infrastructure.FSM;
using Infrastructure.Services;
using Setting;
using Shop;

namespace Infrastruct
{
    public class Game
    {
        public StartGameStateMachine startGameState;

        public Game(GameSettings gameSettings,ShopItems shopItems)
        {
            AllServices services = AllServices.Container;
            
            startGameState = new StartGameStateMachine(services,gameSettings,shopItems);
            var fsm = new FSM<GameState, IState>();
            
            startGameState.Build(fsm);
        }
    }
}
using Infrastruct;
using Infrastructure.FSM;
using Setting;
using Shop;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] 
        private GameSettings _gameSettings;
        [SerializeField] 
        private ShopItems _shopItems;
        
        private Game _game;

        private void Awake()
        {
            _game = new Game(_gameSettings,_shopItems);
            _game.startGameState.Entry(GameState.Init);
            
            //DontDestroyOnLoad(this);
        }
    }
}
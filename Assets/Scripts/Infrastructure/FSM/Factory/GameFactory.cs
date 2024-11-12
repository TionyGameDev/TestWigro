using System.Threading.Tasks;
using Infrastructure.Loader;
using Setting;
using Shop;
using UI;
using UnityEngine;

namespace Infrastructure.FSM.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly string path = "UI/Main";
        private IAssetsProvider _assetsProvider;
        public GameFactory(IAssetsProvider assetsProvider) => _assetsProvider = assetsProvider;

        public async Task<GameObject> LoadMainMenu(GameSettings gameSettings,
            StartGameStateMachine startGameStateMachine,ShopItems shopItems)
        {
           var prefab = await _assetsProvider.Instantiate(path);
           var gameObject = Object.Instantiate(prefab);
           var mainHub = gameObject.GetComponent<UIMainHub>();
           if (mainHub != null)
                mainHub.Show(gameSettings,startGameStateMachine,shopItems);

           return gameObject;
        }
    }
}
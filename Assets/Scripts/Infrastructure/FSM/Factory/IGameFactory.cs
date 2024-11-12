using System.Threading.Tasks;
using Infrastructure.Services;
using Setting;
using Shop;
using UnityEngine;

namespace Infrastructure.FSM.Factory
{
    public interface IGameFactory : IService
    {
        public Task<GameObject> LoadMainMenu(GameSettings gameSettings, StartGameStateMachine startGameStateMachine,ShopItems items);
    }
}
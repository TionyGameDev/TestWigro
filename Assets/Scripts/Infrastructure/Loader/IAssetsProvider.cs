using System.Threading.Tasks;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Loader
{
    public interface IAssetsProvider : IService
    {
        T LoadAssets<T>(string address) where T : Object;

        Task<GameObject> Instantiate(string path);
    }
}
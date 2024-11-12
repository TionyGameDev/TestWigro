using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Loader
{
    public class ResourcesLoader : IAssetsProvider
    {
        public T LoadAssets<T>(string address) where T : Object => (T)Resources.Load<T>(address);

        async Task<GameObject> IAssetsProvider.Instantiate(string path) => (GameObject) Resources.LoadAsync<GameObject>(path).asset;
    }
}
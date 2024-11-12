using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Loader;
using Infrastructure.Singleton;
using UI.MVC;
using UnityEngine;

namespace UI.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        private IAssetsProvider _assetsProvider;
        private readonly string startPath = "UI/Popups/";
        private Dictionary<string, GameObject> _dictionary = new Dictionary<string, GameObject>();
        private int _index;
        public void SetProvider(IAssetsProvider provider)
        {
            _assetsProvider = provider;
        }

        public TPopup Open<TPopup>(IController controller) where TPopup : MonoBehaviour , IViewer
        {
            if (_dictionary.TryGetValue(controller.ToString(), out var gameObj))
            {
                if (GetPopup(controller, gameObj, out TPopup viewer)) 
                    return viewer;
            }
            
            var prefab = CreatePopups(typeof(TPopup).Name);
            if (prefab)
            {
                var popupObj = InstantiatePopup(prefab);
                if (popupObj)
                {
                    GetPopup<TPopup>(controller, popupObj, out var popup);
                    _dictionary.Add(controller.ToString(), popupObj);
                    
                    return popup;
                }
            }
            
            return null;
        }
        private bool GetPopup<TPopup>(IController controller, GameObject gameObj, out TPopup viewer) where TPopup : MonoBehaviour, IViewer
        {
            var popup = gameObj.GetComponent<TPopup>();
            if (popup != null)
            {
                gameObj.gameObject.SetActive(true);
                viewer = popup;
                _index++;
                viewer.SetController(controller,_index);
                controller.Show();
                SetParent(gameObj,null);
                return true;
                
            }

            viewer = null;
            return false;
        }

        private async Task<GameObject> CreatePopup(string name) => await _assetsProvider.Instantiate(startPath + name);
        private GameObject CreatePopups(string name) => _assetsProvider.LoadAssets<GameObject>(startPath + name);

        private GameObject InstantiatePopup(GameObject gameObject) => Instantiate(gameObject);

        public void Close(IController controller)
        {
            if (_dictionary.TryGetValue(controller.ToString(), out var gameObj))
            {
                gameObj.SetActive(false);
                SetParent(gameObj,transform);
            }
        }

        private void SetParent(GameObject gameObj,Transform parent)
        {
            gameObj.transform.SetParent(parent);
        }
    }
}
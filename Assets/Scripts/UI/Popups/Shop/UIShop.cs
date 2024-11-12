using Shop;
using UI.MVC;
using UI.UICoillection;
using UnityEngine;

namespace UI.Popups.Shop
{
    public class UIShop : BaseViewer<UIShopController>
    {
        [SerializeField] private UICollection _collection;

        public void Init(ShopItems items) => _collection.Set(items.items);

        public override void OnClose() => Debug.Log("OnClose");
        public override void OnShow() => Debug.Log("OnShow");

        public void Close() => controller.Close();
    }
}
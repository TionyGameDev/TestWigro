using System.Threading.Tasks;
using Shop;
using UI.Managers;
using UI.MVC;
using UI.Popups.Dialog;

namespace UI.Popups.Shop
{
    public class UIShopController : BaseController<UIShop>
    {
        private ShopItems items;
        public UIShopController(ShopItems itemsShop) => items = itemsShop;

        public async override void Show()
        {
            base.Show();
            await SetAction(items);
            viewer.Init(items);
            
        }

        public async Task SetAction(ShopItems shopItems)
        {
            for (int i = 0; i < shopItems.items.Count; i++)
                shopItems.items[i].action += item => OpenDialogPopup(item);
            
        }
        public void OpenDialogPopup (ShopItem item) => UIManager.Instance.Open<UIDialog>(new UIDialogController(item));
    }
}
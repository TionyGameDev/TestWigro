using Shop;
using UI.MVC;

namespace UI.Popups.Dialog
{
    public class UIDialogController : BaseController<UIDialog>
    {
        private ShopItem _shopItem;
        public UIDialogController(ShopItem shopItem)
        {
            _shopItem = shopItem;
        }

        public override void Show()
        {
            base.Show();

            viewer.ShowItem(_shopItem);
        }
    }
}
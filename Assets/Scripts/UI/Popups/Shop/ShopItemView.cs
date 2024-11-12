using Shop;
using TMPro;
using UI.UICoillection.Drawer;
using UnityEngine.UI;

namespace UI.Popups.Shop
{
    public class ShopItemView : UiDrawer<ShopItem>
    {
        public Image itemImage;
        public TextMeshProUGUI itemDescription;
        public Button buyButton;

        public void Initialize(ShopItem itemView)
        {
          
        }

        protected override void DrawModel(ShopItem target)
        {
            itemImage.sprite = target.sprite;
            itemDescription.text = target.description;
            buyButton.onClick.AddListener(() => target.action.Invoke(target));
        }
    }
}
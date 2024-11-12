using Shop;
using TMPro;
using UI.MVC;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups.Dialog
{
    public class UIDialog : BaseViewer<UIDialogController>
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _textDescription;
        [SerializeField] private Button _buyBtn;
        [SerializeField] private Button _cancelBtn;
        private ShopItem _item;
        public override void OnShow()
        {
            if (_buyBtn)
            {
                _buyBtn.onClick.AddListener(Buy);
                _buyBtn.onClick.AddListener(controller.Close);
            }
            if (_cancelBtn)
                _cancelBtn.onClick.AddListener(controller.Close);
        }

        public override void OnClose()
        {
            base.OnClose();
            if (_buyBtn)
                _buyBtn.onClick.RemoveAllListeners();
            if (_cancelBtn)
                _cancelBtn.onClick.RemoveAllListeners();
            
        }

        public void ShowItem(ShopItem item)
        {
            _item = item;
            if (_icon)
                _icon.sprite = item.sprite;
        }

        private void Buy() => Debug.LogError($"Вы купили - {_item.name}");
    }
}
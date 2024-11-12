using System;
using Infrastructure;
using Infrastructure.FSM;
using Setting;
using Shop;
using UI.Managers;
using UI.Popups;
using UI.Popups.Setting;
using UI.Popups.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIMainHub : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Button _shopBtn;
        [SerializeField] private Button _settingBtn;
        [SerializeField] private Button _quitBtn;
        private GameSettings _gameSettings;
        private StartGameStateMachine _stateMachine;
        private ShopItems _items;
        private void Awake()
        {
           if (_shopBtn)
               SetButton(_shopBtn,OpenShop);
           if (_settingBtn)
               SetButton(_settingBtn,OpenSetting);
           if (_quitBtn)
               SetButton(_quitBtn,Quit);
        }

        public void Show(GameSettings gameSettings, StartGameStateMachine stateMachine, ShopItems items)
        {
            _gameSettings = gameSettings;
            _stateMachine = stateMachine;
            _items = items;
            SetRender();
        }

        private void SetRender()
        {
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = Camera.main;
        }

        private void OpenShop() => UIManager.Instance.Open<UIShop>(new UIShopController(_items));

        private void OpenSetting() => UIManager.Instance.Open<UISetting>(new UISettingController(_gameSettings));

        private void Quit() => _stateMachine.Entry(GameState.Finish);

        private void SetButton(Button button, Action action) => button.onClick.AddListener(action.Invoke);
    }
}
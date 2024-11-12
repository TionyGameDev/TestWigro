using Infrastructure;
using Setting;
using UI.MVC;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups.Setting
{
    public class UISetting : BaseViewer<UISettingController>
    {
        [SerializeField] private Toggle _musicSetting;
        [SerializeField] private Toggle _soundSetting;

        private GameSettings _settings;

        public override void OnShow() { }

        public void SetGameSetting(GameSettings settings)
        {
            _settings = settings;
            Init();
        }

        private void Init()
        {
            if (_musicSetting)
            {
                _musicSetting.isOn = _settings.isMusic;
                _musicSetting.onValueChanged.AddListener(_settings.ToggleMusic);
            }
            
            if (_soundSetting)
            {
                _soundSetting.isOn = _settings.isSound;
                _soundSetting.onValueChanged.AddListener(_settings.ToggleSound);
            }
            
        }

        public override void OnClose()
        {
            base.OnClose();
            _musicSetting.onValueChanged.RemoveAllListeners();
            _soundSetting.onValueChanged.RemoveAllListeners();
        }
    }
}
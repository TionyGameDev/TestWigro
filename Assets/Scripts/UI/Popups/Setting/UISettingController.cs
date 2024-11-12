using Infrastructure;
using Setting;
using UI.MVC;

namespace UI.Popups.Setting
{
    public class UISettingController : BaseController<UISetting>
    {
        private GameSettings _gameSettings;
        public UISettingController(GameSettings gameSettings) : base()
        {
            _gameSettings = gameSettings;
        }

        public override void Show()
        {
            base.Show();
            
            viewer.SetGameSetting(_gameSettings);
        }
    }
}
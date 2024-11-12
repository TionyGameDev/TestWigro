using UnityEngine;
using UnityEngine.UI;

namespace UI.Instruments
{
    public class ToggleUI : MonoBehaviour , IUIClass
    {
        [SerializeField] private Toggle _toggle;


        public void Init()
        {
            if (!_toggle)
                return;
            
        }

        public void Disable()
        {
            
        }
    }
}
using UnityEngine;

namespace Setting
{
    [CreateAssetMenu(fileName = "SettingsData", menuName = "Settings/SettingsData")]
    public class GameSettings : ScriptableObject
    {
        public bool isMusic = true;
        public bool isSound = true;
        
        public void ToggleMusic(bool state)
        {
            isMusic = state;
            Debug.Log("Music toggled: " + (isMusic ? "On" : "Off"));
        }

        public void ToggleSound(bool state)
        {
            isSound = state;
            Debug.Log("Sound toggled: " + (isSound ? "On" : "Off"));
        }
    }
}
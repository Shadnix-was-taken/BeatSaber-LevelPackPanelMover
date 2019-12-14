using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using UnityEngine;

namespace Level_Pack_Panel_Mover.UI
{
    public class Settings : PersistentSingleton<Settings>
    {
        [UIParams]
        private BSMLParserParams parserParams;

        [UIValue("panel-position-x")]
        public int PanelPositionX
        {
            get => (int)(ModConfig.bottomPanelPosition.x * 100);
            set => ModConfig.bottomPanelPosition.x = value / 100f;
        }

        [UIValue("panel-position-y")]
        public int PanelPositionY
        {
            get => (int)(ModConfig.bottomPanelPosition.y * 100);
            set => ModConfig.bottomPanelPosition.y = value / 100f;
        }

        [UIValue("panel-position-z")]
        public int PanelPositionZ
        {
            get => (int)(ModConfig.bottomPanelPosition.z * 100);
            set => ModConfig.bottomPanelPosition.z = value / 100f;
        }

        [UIValue("panel-rotation-x")]
        public int PanelRotationX
        {
            get => (int)ModConfig.bottomPanelRotation.eulerAngles.x;
            set => ModConfig.bottomPanelRotation = Quaternion.Euler(value, 0, 0);
        }

        [UIAction("#apply")]
        public void OnApply() => ModConfig.Save();

        [UIAction("#ok")]
        public void OnOk() => ModConfig.Save();
    }
}

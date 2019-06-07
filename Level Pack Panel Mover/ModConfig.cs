using BS_Utils.Utilities;
using UnityEngine;

namespace Level_Pack_Panel_Mover
{
    public static class ModConfig
    {
        internal static Config cfgProvider = new Config("LevelPackPanelMover");
        public static Vector3 bottomPanelPosition = new Vector3(0,0,0);
        public static Quaternion bottomPanelRotation = new Quaternion();

        static ModConfig()
        {
            Load();
        }

        public static void Load()
        {
            bottomPanelPosition.x = cfgProvider.GetInt("BottomPanel", "posx", 0, true) / 100f;
            bottomPanelPosition.y = cfgProvider.GetInt("BottomPanel", "posy", -40, true) / 100f;
            bottomPanelPosition.z = cfgProvider.GetInt("BottomPanel", "posz", 20, true) / 100f;

            // Don't change y or z rotation - interface the interface breaks without further modifications
            float rotx = cfgProvider.GetInt("BottomPanel", "rotx", 25, true);
            bottomPanelRotation = Quaternion.Euler(rotx, 0, 0);
        }

        public static void Save()
        {
            cfgProvider.SetInt("BottomPanel", "posx", (int)(bottomPanelPosition.x * 100));
            cfgProvider.SetInt("BottomPanel", "posy", (int)(bottomPanelPosition.y * 100));
            cfgProvider.SetInt("BottomPanel", "posz", (int)(bottomPanelPosition.z * 100));

            Vector3 rotation = bottomPanelRotation.eulerAngles;
            cfgProvider.SetInt("BottomPanel", "rotx", (int)rotation.x);
        }
    }
}

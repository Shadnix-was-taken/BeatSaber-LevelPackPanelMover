using IPA;
using IPA.Config;
using IPA.Utilities;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace Level_Pack_Panel_Mover
{
    public class Plugin : IBeatSaberPlugin
    {
        public const string Name = "Level Pack Panel Mover";
        public const string Version = "0.2.0";

        public void Init(object thisWillBeNull, IPALogger logger)
        {
            Logger.log = logger;
        }

        public void OnApplicationStart()
        {

        }

        public void OnApplicationQuit()
        {

        }

        public void OnFixedUpdate()
        {

        }

        public void OnUpdate()
        {

        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {

        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            // Check what scenes get loaded...
            if (scene.name == "MenuCore")
            {
                Logger.log.Info("MenuCore loaded...");
                Settings.Load();

                GameObject menuCoreWrapper = scene.GetRootGameObjects().First();
                var bottomScreen = menuCoreWrapper.transform.Find("ScreenSystem")?.transform.Find("BottomScreen");

                if (bottomScreen == null)
                {
                    Logger.log.Error("Couldn't find BottomScreen in ScreenSystem - maybe the game structure changed?");
                    return;
                }

                bottomScreen.Translate(Settings.bottomPanelPosition);
                bottomScreen.Rotate(Settings.bottomPanelRotation.eulerAngles);
            }

        }

        public void OnSceneUnloaded(Scene scene)
        {

        }
    }
}

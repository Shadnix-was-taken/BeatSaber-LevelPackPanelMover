using BeatSaberMarkupLanguage.Settings;
using IPA;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace Level_Pack_Panel_Mover
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public const string Name = "Level Pack Panel Mover";
        public const string Version = "1.9.0";

        [Init]
        public void Init(object thisWillBeNull, IPALogger logger)
        {
            Logger.log = logger;
        }

        [OnStart]
        public void OnStart()
        {
            AddEvents();
        }

        [OnExit]
        public void OnExit()
        {
            // Save settings
            ModConfig.Save();
            RemoveEvents();
        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            if (nextScene.name == "MenuViewControllers" && prevScene.name == "EmptyTransition")
            {
                BSMLSettings.instance.AddSettingsMenu("Bottom Panel Mover", "Level_Pack_Panel_Mover.UI.Settings.bsml", UI.Settings.instance);
            }
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            // Check what scenes get loaded...
            if (scene.name == "MenuCore")
            {
                Logger.log.Info("MenuCore loaded...");

                ModConfig.Load();

                GameObject menuCoreWrapper = scene.GetRootGameObjects().First();
                var bottomScreen = menuCoreWrapper.transform.Find("ScreenSystem")?.transform.Find("BottomScreen");

                if (bottomScreen == null)
                {
                    Logger.log.Error("Couldn't find BottomScreen in ScreenSystem - maybe the game structure changed?");
                    return;
                }

                bottomScreen.Translate(ModConfig.bottomPanelPosition, Space.World);
                bottomScreen.Rotate(ModConfig.bottomPanelRotation.eulerAngles, Space.World);
            }

        }

        private void AddEvents()
        {
            RemoveEvents();
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void RemoveEvents()
        {
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

    }
}

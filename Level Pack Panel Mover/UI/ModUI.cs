using CustomUI.Settings;
using System;
using System.Reflection;
using UnityEngine;

namespace Level_Pack_Panel_Mover.UI
{
    class ModUI
    {
        public static void CreateSettingsOptionsUI()
        {
            SubMenu settingsMenu = SettingsUI.CreateSubMenu("Lvl Pack Panel Mover");

            BoolViewController posTxtCtrl = settingsMenu.AddBool("Offset of default position. All values in cm.", "Set all values to 0 to put the panel back to the default position.");
            posTxtCtrl.GetValue += delegate { return false; };
            posTxtCtrl.SetValue += delegate (bool value) { };

            // Hack to convert bool segment to text only (based on hack in BSTweaks mod)
            try
            {
                var posTxtCtrlButtonToDisable = posTxtCtrl.GetType().BaseType.BaseType.GetField("_decButton", BindingFlags.NonPublic | BindingFlags.Instance);
                var posTxtCtrlDecButton = (MonoBehaviour)posTxtCtrlButtonToDisable.GetValue(posTxtCtrl);
                posTxtCtrlButtonToDisable = posTxtCtrl.GetType().BaseType.BaseType.GetField("_incButton", BindingFlags.NonPublic | BindingFlags.Instance);
                var posTxtCtrlIncButton = (MonoBehaviour)posTxtCtrlButtonToDisable.GetValue(posTxtCtrl);

                posTxtCtrlDecButton.gameObject.SetActive(false);
                posTxtCtrlIncButton.gameObject.SetActive(false);

                var posTxtCtrlTextToDisable = posTxtCtrl.GetType().BaseType.BaseType.GetField("_text", BindingFlags.NonPublic | BindingFlags.Instance);
                var posTxtCtrlUselessText = (MonoBehaviour)posTxtCtrlTextToDisable.GetValue(posTxtCtrl);

                posTxtCtrlUselessText.gameObject.SetActive(false);
            }
            catch (Exception ex)
            {
                Logger.log.Error("Error trying to disable first comment in settings menu:" + ex.ToString());
            }

            IntViewController posxCtrl = settingsMenu.AddInt("Left/Right (X-Axis)", -1000, 1000, 10);
            posxCtrl.GetValue += delegate { return (int)(ModConfig.bottomPanelPosition.x * 100); };
            posxCtrl.SetValue += delegate (int value) { ModConfig.bottomPanelPosition.x = value / 100f; ModConfig.Save(); };

            IntViewController posyCtrl = settingsMenu.AddInt("Up/Down (Y-Axis)", -1000, 1000, 10);
            posyCtrl.GetValue += delegate { return (int)(ModConfig.bottomPanelPosition.y * 100); };
            posyCtrl.SetValue += delegate (int value) { ModConfig.bottomPanelPosition.y = value / 100f; ModConfig.Save(); };

            IntViewController poszCtrl = settingsMenu.AddInt("Front/Back (Z-Axis)", -1000, 1000, 10);
            poszCtrl.GetValue += delegate { return (int)(ModConfig.bottomPanelPosition.z * 100); };
            poszCtrl.SetValue += delegate (int value) { ModConfig.bottomPanelPosition.z = value / 100f; ModConfig.Save(); };

            BoolViewController rotTxtCtrl = settingsMenu.AddBool("Set rotation to/from main platform in degrees.");
            rotTxtCtrl.GetValue += delegate { return false; };
            rotTxtCtrl.SetValue += delegate (bool value) { };

            // Hack to convert bool segment to text only (based on hack in BSTweaks mod)
            try
            {
                var rotTxtCtrlButtonToDisable = rotTxtCtrl.GetType().BaseType.BaseType.GetField("_decButton", BindingFlags.NonPublic | BindingFlags.Instance);
                var rotTxtCtrlDecButton = (MonoBehaviour)rotTxtCtrlButtonToDisable.GetValue(rotTxtCtrl);
                rotTxtCtrlButtonToDisable = rotTxtCtrl.GetType().BaseType.BaseType.GetField("_incButton", BindingFlags.NonPublic | BindingFlags.Instance);
                var rotTxtCtrlIncButton = (MonoBehaviour)rotTxtCtrlButtonToDisable.GetValue(rotTxtCtrl);

                rotTxtCtrlDecButton.gameObject.SetActive(false);
                rotTxtCtrlIncButton.gameObject.SetActive(false);

                var rotTxtCtrlTextToDisable = rotTxtCtrl.GetType().BaseType.BaseType.GetField("_text", BindingFlags.NonPublic | BindingFlags.Instance);
                var rotTxtCtrlUselessText = (MonoBehaviour)rotTxtCtrlTextToDisable.GetValue(rotTxtCtrl);

                rotTxtCtrlUselessText.gameObject.SetActive(false);
            }
            catch (Exception ex)
            {
                Logger.log.Error("Error trying to disable first comment in settings menu:" + ex.ToString());
            }

            IntViewController rotxCtrl = settingsMenu.AddInt("X-Axis", -360, 360, 5);
            rotxCtrl.GetValue += delegate { return (int)ModConfig.bottomPanelRotation.eulerAngles.x; };
            rotxCtrl.SetValue += delegate (int value) { ModConfig.bottomPanelRotation = Quaternion.Euler(value, 0, 0); ModConfig.Save(); };
        }
    }
}

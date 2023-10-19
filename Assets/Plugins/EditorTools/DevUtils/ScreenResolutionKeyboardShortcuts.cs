using System;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace EditorTools.DevUtils
{
    [Serializable]
    public struct ScreenResolutionConfig
    {
        public KeyCode key;
        public int     width;
        public int     height;
        public uint    refreshRate;

        public RefreshRate RefreshRate => new() { numerator = refreshRate, denominator = 1 };
    }

    public class ScreenResolutionKeyboardShortcuts : MonoBehaviour
    {
        [SerializeField] private List<ScreenResolutionConfig> resolutions;

        [SerializeField] private KeyCode fullScreenModeToggleKey;

        [SerializeField] private bool checkForCtrl;
        [SerializeField] private bool checkForAlt;

        private void UpdateScreenResolution(ScreenResolutionConfig config) {
            var screenMode = Screen.fullScreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;

            Screen.SetResolution(config.width, config.height, screenMode, config.RefreshRate);
        }

        private void UpdateFullScreenMode() {
            Screen.fullScreen = !Screen.fullScreen;
        }

        private void Update() {
            if (!ModifierPresent()) return;

            if (Input.GetKeyDown(fullScreenModeToggleKey))
            {
                Debug.Log("Toggle full screen mode");
                UpdateFullScreenMode();
            }

            foreach (var resolutionConfig in resolutions)
            {
                if (Input.GetKeyDown(resolutionConfig.key))
                {
                    Debug.Log("Resolution: " + resolutionConfig.width + "x" + resolutionConfig.height + " @ " +
                              resolutionConfig.RefreshRate);
                    UpdateScreenResolution(resolutionConfig);
                }
            }
        }


        private bool ModifierPresent() {
            var ctrl = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
            var alt  = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);

            var ctrOk = !checkForCtrl || (checkForCtrl && ctrl);
            var altOk = !checkForAlt || (checkForAlt && alt);

            return ctrOk && altOk;
        }
    }
}
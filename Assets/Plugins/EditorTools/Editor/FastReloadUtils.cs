using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace EditorTools.Editor
{
    public static class FastReloadUtils
    {
        private const string RED   = "#500000";
        private const string GREEN = "#005000";

        [MenuItem("Tools/Fast Reload/Toggle Fast Play Mode &#%f")]
        public static void ToggleFastPlayMode() {
            EditorSettings.enterPlayModeOptionsEnabled = !EditorSettings.enterPlayModeOptionsEnabled;

            AssetDatabase.Refresh();

            var color = EditorSettings.enterPlayModeOptionsEnabled ? GREEN : RED;
            var text  = EditorSettings.enterPlayModeOptionsEnabled ? "Enabled" : "Disabled";

            Debug.Log($"Fast Play Mode: <color={color}>{text}</color>");
        }

        [MenuItem("Tools/Fast Reload/Reload Domain &#%d")]
        public static void ReloadDomain() {
            EditorUtility.RequestScriptReload();
            AssetDatabase.Refresh();

            Debug.Log($"Reloading Domain: <color={GREEN}>DONE</color>");
        }
    }
}
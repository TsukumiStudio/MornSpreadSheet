using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MornLib
{
    internal static class MornSpreadSheetUtil
    {
        private const string Prefix = "[<color=#7cb342>MornSpreadSheet</color>] ";

        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        internal static void Log(object message)
        {
            Debug.Log($"{Prefix}{message}");
        }

        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        internal static void LogWarning(object message)
        {
            Debug.LogWarning($"{Prefix}{message}");
        }

        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        internal static void LogError(object message)
        {
            Debug.LogError($"{Prefix}{message}");
        }

        internal static void SetDirty(Object target)
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(target);
#endif
        }
    }
}

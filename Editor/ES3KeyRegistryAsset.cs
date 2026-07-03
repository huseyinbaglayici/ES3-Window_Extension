using System.IO;
using UnityEditor;
using UnityEngine;

namespace ES3KeyManager.Editor
{
    internal static class ES3KeyRegistryAsset
    {
        const string ResourcesFolder = "Assets/Resources";
        const string AssetPath = ResourcesFolder + "/ES3KeyRegistry.asset";

        public static ES3KeyRegistry LoadOrCreate()
        {
            var registry = AssetDatabase.LoadAssetAtPath<ES3KeyRegistry>(AssetPath);
            if (registry != null)
                return registry;

            if (!Directory.Exists(ResourcesFolder))
                Directory.CreateDirectory(ResourcesFolder);

            registry = ScriptableObject.CreateInstance<ES3KeyRegistry>();
            AssetDatabase.CreateAsset(registry, AssetPath);
            AssetDatabase.SaveAssets();
            return registry;
        }
    }
}

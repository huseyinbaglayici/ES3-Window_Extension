using UnityEditor;
using UnityEngine;

namespace ES3KeyManager.Editor
{
    public class ES3KeyManagerWindow : EditorWindow
    {
        ES3KeyRegistry _registry;
        Vector2 _scroll;

        [MenuItem("Window/ES3 Key Manager")]
        static void Open() => GetWindow<ES3KeyManagerWindow>("ES3 Key Manager");

        void OnEnable() => _registry = ES3KeyRegistryAsset.LoadOrCreate();

        void OnGUI()
        {
            if (_registry == null)
            {
                _registry = ES3KeyRegistryAsset.LoadOrCreate();
                return;
            }

            EditorGUILayout.LabelField("ES3 Key Registry", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            _scroll = EditorGUILayout.BeginScrollView(_scroll);

            ES3KeyEntry toRemove = null;
            foreach (var entry in _registry.entries)
            {
                if (ES3KeyEntryDrawer.Draw(entry))
                    toRemove = entry;
            }
            if (toRemove != null)
                _registry.entries.Remove(toRemove);

            EditorGUILayout.EndScrollView();
            EditorGUILayout.Space();

            if (GUILayout.Button("Add Key"))
                _registry.entries.Add(new ES3KeyEntry { key = "NewKey", type = ES3PrimitiveType.Int });

            if (GUI.changed)
            {
                EditorUtility.SetDirty(_registry);
                AssetDatabase.SaveAssets();
            }
        }
    }
}

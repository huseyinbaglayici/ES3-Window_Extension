using UnityEditor;
using UnityEngine;

namespace ES3KeyManager.Editor
{
    internal static class ES3KeyEntryDrawer
    {
        public static bool Draw(ES3KeyEntry entry)
        {
            bool removeRequested = false;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.BeginHorizontal();
            entry.key = EditorGUILayout.TextField("Key", entry.key);
            if (GUILayout.Button("X", GUILayout.Width(22)))
                removeRequested = true;
            EditorGUILayout.EndHorizontal();

            entry.type = (ES3PrimitiveType)EditorGUILayout.EnumPopup("Type", entry.type);
            DrawDefaultField(entry);

            EditorGUILayout.EndVertical();

            return removeRequested;
        }

        static void DrawDefaultField(ES3KeyEntry entry)
        {
            switch (entry.type)
            {
                case ES3PrimitiveType.Int:
                    entry.intDefault = EditorGUILayout.IntField("Default", entry.intDefault);
                    break;
                case ES3PrimitiveType.Float:
                    entry.floatDefault = EditorGUILayout.FloatField("Default", entry.floatDefault);
                    break;
                case ES3PrimitiveType.Bool:
                    entry.boolDefault = EditorGUILayout.Toggle("Default", entry.boolDefault);
                    break;
                case ES3PrimitiveType.String:
                    entry.stringDefault = EditorGUILayout.TextField("Default", entry.stringDefault);
                    break;
                case ES3PrimitiveType.Byte:
                    entry.byteDefault = (byte)EditorGUILayout.IntSlider("Default", entry.byteDefault, 0, 255);
                    break;
            }
        }
    }
}

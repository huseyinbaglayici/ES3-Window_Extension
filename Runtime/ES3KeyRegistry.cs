using System.Collections.Generic;
using UnityEngine;

namespace ES3KeyManager
{
    // Must live at Assets/Resources/ES3KeyRegistry.asset so ES3Keys can load it at runtime.
    [CreateAssetMenu(fileName = "ES3KeyRegistry", menuName = "ES3/Key Registry")]
    public class ES3KeyRegistry : ScriptableObject
    {
        public List<ES3KeyEntry> entries = new List<ES3KeyEntry>();

        public ES3KeyEntry Find(string key)
        {
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].key == key)
                    return entries[i];
            }
            return null;
        }
    }
}

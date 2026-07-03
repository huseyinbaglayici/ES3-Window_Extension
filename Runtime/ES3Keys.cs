using System.Collections.Generic;
using UnityEngine;

namespace ES3KeyManager
{
    /// <summary>
    /// Loads defaults from Resources/ES3KeyRegistry.asset and wraps ES3.Load/Save
    /// so you never hardcode key strings or default values in gameplay code.
    /// </summary>
    public static class ES3Keys
    {
        static ES3KeyRegistry _registry;
        static readonly Dictionary<string, ES3KeyEntry> _cache = new Dictionary<string, ES3KeyEntry>();

        static ES3KeyRegistry Registry
        {
            get
            {
                if (_registry == null)
                {
                    _registry = Resources.Load<ES3KeyRegistry>("ES3KeyRegistry");
                    if (_registry == null)
                        Debug.LogError("ES3Keys: Resources/ES3KeyRegistry.asset not found.");
                }
                return _registry;
            }
        }

        static ES3KeyEntry GetEntry(string key)
        {
            if (_cache.TryGetValue(key, out var cached))
                return cached;

            var entry = Registry != null ? Registry.Find(key) : null;
            if (entry == null)
            {
                Debug.LogError($"ES3Keys: key '{key}' not found in registry.");
                return null;
            }

            _cache[key] = entry;
            return entry;
        }

        public static int LoadInt(string key)
        {
            var e = GetEntry(key);
            return ES3.Load<int>(key, e != null ? e.intDefault : 0);
        }
        public static void SaveInt(string key, int value) => ES3.Save(key, value);

        public static float LoadFloat(string key)
        {
            var e = GetEntry(key);
            return ES3.Load<float>(key, e != null ? e.floatDefault : 0f);
        }
        public static void SaveFloat(string key, float value) => ES3.Save(key, value);

        public static bool LoadBool(string key)
        {
            var e = GetEntry(key);
            return ES3.Load<bool>(key, e != null && e.boolDefault);
        }
        public static void SaveBool(string key, bool value) => ES3.Save(key, value);

        public static string LoadString(string key)
        {
            var e = GetEntry(key);
            return ES3.Load<string>(key, e != null ? e.stringDefault : string.Empty);
        }
        public static void SaveString(string key, string value) => ES3.Save(key, value);

        public static byte LoadByte(string key)
        {
            var e = GetEntry(key);
            return ES3.Load<byte>(key, e != null ? e.byteDefault : (byte)0);
        }
        public static void SaveByte(string key, byte value) => ES3.Save(key, value);

        /// <summary>Clears the cache, e.g. after editing the registry at runtime in the editor.</summary>
        public static void ClearCache() => _cache.Clear();
    }
}

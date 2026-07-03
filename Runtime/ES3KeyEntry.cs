using System;

namespace ES3KeyManager
{
    public enum ES3PrimitiveType
    {
        Int,
        Float,
        Bool,
        String,
        Byte
    }

    [Serializable]
    public class ES3KeyEntry
    {
        public string key;
        public ES3PrimitiveType type;

        public int intDefault;
        public float floatDefault;
        public bool boolDefault;
        public string stringDefault;
        public byte byteDefault;
    }
}

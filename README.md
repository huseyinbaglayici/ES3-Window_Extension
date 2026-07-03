# ES3 Key Manager

Editor window for defining Easy Save 3 keys (name, type, default value) in one place, instead of hardcoding strings across the project.

Requires [Easy Save 3](https://assetstore.unity.com/packages/tools/utilities/easy-save-the-complete-save-data-serialization-asset-768) (not included).

## Install

1. Enable ES3's assembly definitions: `Tools > Easy Save 3 > Enable Assembly Definition Files`
2. Package Manager > Add package from git URL:

```
https://github.com/huseyinbaglayici/ES3-Window_Extension.git
```

## Usage

Open `Window > ES3 Key Manager`, add keys with a type and default value. The registry asset is created at `Assets/Resources/ES3KeyRegistry.asset` automatically.

```csharp
using ES3KeyManager;

int currency = ES3Keys.LoadInt("Currency"); // returns the default from the registry if not saved yet
ES3Keys.SaveInt("Currency", currency + 10);
```

Supported types: int, float, bool, string, byte.

## License

MIT

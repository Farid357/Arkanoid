using UnityEngine;

public sealed class PlayerPrefsStorage : IStorage, IExistable
{
    public bool Exists(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public T Load<T>(string key, T loadObject)
    {
        if (Exists(key))
        {
            string loadJson = PlayerPrefs.GetString(key);
            loadObject = JsonUtility.FromJson<T>(loadJson);
        }
        return loadObject;
    }

    public void Save<T>(string key, T saveObject)
    {
        var saveJson = JsonUtility.ToJson(saveObject);
        PlayerPrefs.SetString(key, saveJson);
        PlayerPrefs.Save();
    }
}

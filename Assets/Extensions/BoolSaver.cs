using UnityEngine;

public static class BoolSaver
{
    public static bool GetBool(this PlayerPrefs playerPrefs, string key)
    {
        return PlayerPrefs.GetInt(key) == 0;
    }
    public static void SetBool(this PlayerPrefs playerPrefs, string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 0 : 1 );
    }
}

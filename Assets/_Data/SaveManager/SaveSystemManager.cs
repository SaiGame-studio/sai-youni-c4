using UnityEngine;

public class SaveSystemManager : SaveManager
{
    /// <summary>
    /// Saves an integer value using PlayerPrefs.
    /// </summary>
    public override void SaveInit(string keyName, int number)
    {
        if (string.IsNullOrEmpty(keyName))
        {
            Debug.LogError("Key name cannot be null or empty.");
            return;
        }

        SaveSystem.SetInt(keyName, number);
        Debug.Log($"PlayerPrefs: Saved {number} with key '{keyName}'");
    }

    /// <summary>
    /// Loads an integer value from PlayerPrefs.
    /// </summary>
    public override int LoadInit(string keyName, int defaultValue = 0)
    {
        if (string.IsNullOrEmpty(keyName))
        {
            Debug.LogError("Key name cannot be null or empty.");
            return defaultValue;
        }

        if (PlayerPrefs.HasKey(keyName))
        {
            int value = SaveSystem.GetInt(keyName);
            Debug.Log($"PlayerPrefs: Loaded value {value} for key '{keyName}'");
            return value;
        }
        else
        {
            Debug.LogWarning($"PlayerPrefs: Key '{keyName}' not found. Returning default value {defaultValue}");
            return defaultValue;
        }
    }
}

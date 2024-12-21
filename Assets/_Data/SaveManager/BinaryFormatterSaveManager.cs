using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinaryFormatterSaveManager : SaveManager
{
    private string saveDirectory;

    public BinaryFormatterSaveManager()
    {
        saveDirectory = Application.persistentDataPath + "/SaveData/";
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }
    }

    /// <summary>
    /// Saves an integer value using BinaryFormatter.
    /// </summary>
    public override void SaveInit(string keyName, int number)
    {
        if (string.IsNullOrEmpty(keyName))
        {
            Debug.LogError("Key name cannot be null or empty.");
            return;
        }

        string filePath = saveDirectory + keyName + ".dat";

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            formatter.Serialize(stream, number);
        }

        Debug.Log($"BinaryFormatter: Saved {number} to '{filePath}'");
    }

    /// <summary>
    /// Loads an integer value using BinaryFormatter.
    /// </summary>
    public override int LoadInit(string keyName, int defaultValue = 0)
    {
        if (string.IsNullOrEmpty(keyName))
        {
            Debug.LogError("Key name cannot be null or empty.");
            return defaultValue;
        }

        string filePath = saveDirectory + keyName + ".dat";

        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                int value = (int)formatter.Deserialize(stream);
                Debug.Log($"BinaryFormatter: Loaded value {value} from '{filePath}'");
                return value;
            }
        }
        else
        {
            Debug.LogWarning($"BinaryFormatter: File '{filePath}' not found. Returning default value {defaultValue}");
            return defaultValue;
        }
    }
}

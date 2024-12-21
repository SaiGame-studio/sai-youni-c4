using UnityEngine;

public abstract class SaveManager : SaiBehaviour
{
    /// <summary>
    /// Abstract method to save an integer value.
    /// </summary>
    /// <param name="keyName">The key name used to store the value.</param>
    /// <param name="number">The integer value to be saved.</param>
    public abstract void SaveInit(string keyName, int number);

    /// <summary>
    /// Abstract method to load an integer value.
    /// </summary>
    /// <param name="keyName">The key name used to retrieve the value.</param>
    /// <param name="defaultValue">The default value to return if the key does not exist.</param>
    /// <returns>The integer value loaded.</returns>
    public abstract int LoadInit(string keyName, int defaultValue = 0);
}

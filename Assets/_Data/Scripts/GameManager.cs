using UnityEngine;

public class GameManager : SaiSingleton<GameManager>
{
    [SerializeField] protected SaveManager save;
    public SaveManager Save => save;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSaveManager();
    }

    protected virtual void LoadSaveManager()
    {
        if (this.save != null) return;
        this.save = GetComponentInChildren<SaveManager>();
        Debug.Log(transform.name + ": LoadSaveManager", gameObject);
    }


    public virtual void QuitGame()
    {
        InventoriesManager.Instance.SaveGameData();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

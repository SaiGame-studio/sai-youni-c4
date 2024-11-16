using UnityEngine;

public class InputHotkeys : SaiSingleton<InputHotkeys>
{
    protected bool isToogleInventoryUI = false;
    public bool IsToogleInventoryUI => isToogleInventoryUI;

    protected bool isToogleMusic = false;
    public bool IsToogleMusic => isToogleMusic;

    protected bool isToogleSetting = false;
    public bool IsToogleSetting => isToogleSetting;


    protected virtual void Update()
    {
        this.OpenInventory();
        this.ToogleMusic();
        this.ToogleSetting();
    }

    protected virtual void OpenInventory()
    {
        this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }

    protected virtual void ToogleMusic()
    {
        this.isToogleMusic = Input.GetKeyUp(KeyCode.M);
    }

    protected virtual void ToogleSetting()
    {
        this.isToogleSetting = Input.GetKeyUp(KeyCode.N);
    }
}

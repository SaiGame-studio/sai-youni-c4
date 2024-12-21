using System.Collections.Generic;
using UnityEngine;

public class InputHotkeys : SaiSingleton<InputHotkeys>
{
    protected bool isToogleInventoryUI = false;
    public bool IsToogleInventoryUI => isToogleInventoryUI;

    protected bool isToogleMusic = false;
    public bool IsToogleMusic => isToogleMusic;

    protected bool isToogleSetting = false;
    public bool IsToogleSetting => isToogleSetting;

    [SerializeField] protected KeyCode keyCode;
    public KeyCode KeyCode => keyCode;

    [SerializeField] protected bool isPlaceTower;
    public bool IsPlaceTower => isPlaceTower;


    protected virtual void Update()
    {
        this.OpenInventory();
        this.ToogleMusic();
        this.ToogleSetting();
        this.ToogleNumber();
    }

    protected virtual void OpenInventory()
    {
        this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }

    protected virtual void ToogleNumber()
    {
        this.isPlaceTower = Input.GetKey(KeyCode.C);

        for (int i = 1; i <= 9; i++) 
        {
            KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + i);
            if (Input.GetKeyDown(key)) 
            {
                this.keyCode = this.keyCode == key ? KeyCode.None : key;
                break; 
            }
        }
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

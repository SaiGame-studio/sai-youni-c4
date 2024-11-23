using UnityEngine;

public class BtnCloseInventory : ButttonAbstract
{
    public override void OnClick()
    {
        UIInventory.Instance.Hide();
    }
}

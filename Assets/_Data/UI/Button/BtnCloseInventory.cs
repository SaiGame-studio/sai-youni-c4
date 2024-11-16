using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseInventory : ButttonAbstract
{
    public override void OnClick()
    {
        UIInventory.Instance.Hide();
    }
}

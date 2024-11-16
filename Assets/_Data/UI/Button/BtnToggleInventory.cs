using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnToggleInventory : ButttonAbstract
{
    public override void OnClick()
    {
        UIInventory.Instance.Toggle();
        
    }
}

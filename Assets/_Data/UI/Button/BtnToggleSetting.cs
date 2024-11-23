using UnityEngine;

public class BtnToggleSetting : ButttonAbstract
{
    public override void OnClick()
    {
        UISetting.Instance.Toggle();
    }
}

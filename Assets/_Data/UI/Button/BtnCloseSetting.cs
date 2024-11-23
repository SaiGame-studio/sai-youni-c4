using UnityEngine;

public class BtnCloseSetting : ButttonAbstract
{
    public override void OnClick()
    {
        UISetting.Instance.Hide();
    }
}

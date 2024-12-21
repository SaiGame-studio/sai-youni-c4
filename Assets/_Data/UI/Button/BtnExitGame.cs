using UnityEngine;

public class BtnExitGame : ButttonAbstract
{
    public override void OnClick()
    {
        GameManager.Instance.QuitGame();
    }
}

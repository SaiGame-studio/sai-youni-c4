using UnityEngine;

public class BtnMusicToggle : ButttonAbstract
{
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleMusic();
    }

    public override void OnClick()
    {
        SoundManager.Instance.ToggleMusic();
    }

    protected virtual void HotkeyToogleMusic()
    {
        //if (InputHotkeys.Instance.isToogleMusic) SoundManager.Instance.ToggleMusic();
    }
}

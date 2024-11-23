using UnityEngine;

public abstract class MusicCtrl : SoundCtrl
{
    protected override void Reset()
    {
        base.Reset();
        this.ResetValue();
        this.LoadComponents();
    }

    protected virtual void ResetValue()
    {
        this.audioSource.loop = true;
    }
}

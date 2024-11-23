using UnityEngine;

public abstract class SFXCtrl : SoundCtrl
{
    protected override void Reset()
    {
        base.Reset();
        this.ResetValue();
        this.LoadComponents();
    }

    protected virtual void ResetValue()
    {
        this.audioSource.spatialBlend = 1;
    }
}

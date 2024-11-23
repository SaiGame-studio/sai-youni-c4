using UnityEngine;

public class MusicDespawn : Despawn<SoundCtrl>
{
    protected override void Reset()
    {
        base.Reset();
        this.ResetValue();
        this.LoadComponents();
    }

    protected virtual void ResetValue()
    {
        this.isDespawnByTime = false;
    }
}

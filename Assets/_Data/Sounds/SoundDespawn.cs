using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDespawn : Despawn<SoundCtrl>
{
    protected override void Reset()
    {
        base.Reset();
        this.ResetValue();
        this.LoadComponents();
    }

    protected virtual void ResetValue()
    {
        this.timeLife = 2f;
        this.currentTime = 2f;
    }
}

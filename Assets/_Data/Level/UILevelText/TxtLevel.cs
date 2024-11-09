using UnityEngine;

public abstract class TxtLevel : Text3DAbstact
{
    protected virtual void FixedUpdate()
    {
        this.UpdateLevel();
    }

    protected virtual void UpdateLevel()
    {
        this.textPro.text = this.GetLevel();
    }

    protected abstract string GetLevel();
}

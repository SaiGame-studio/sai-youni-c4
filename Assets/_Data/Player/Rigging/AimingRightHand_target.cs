using UnityEngine;

public class AimingRightHand_target : SaiBehaviour
{
    protected override void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void ResetValue()
    {
        transform.localPosition = new Vector3(0.209000006f, 0.0759999976f, 0.298999995f);
        transform.localRotation = Quaternion.Euler(new Vector3(9.53907776f, 271.061768f, 268.303101f));
    }
}

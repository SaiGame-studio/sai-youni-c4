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
        transform.localPosition = new Vector3(0.2215742f, 0.177404f, 0.3095092f);
        transform.localRotation = Quaternion.Euler(26.657f, -97.288f, -98.937f);
    }
}

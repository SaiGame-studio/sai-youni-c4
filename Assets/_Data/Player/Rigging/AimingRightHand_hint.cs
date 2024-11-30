using UnityEngine;

public class AimingRightHand_hint : SaiBehaviour
{
    protected override void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void ResetValue()
    {
        transform.localPosition = new Vector3(0.288f, 0.141f, 0.379f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}

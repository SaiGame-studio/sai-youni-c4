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
        transform.localPosition = new Vector3(0.338f, -0.0299999993f, 0.245000005f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}

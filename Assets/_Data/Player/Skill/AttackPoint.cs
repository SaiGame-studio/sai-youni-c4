using UnityEngine;

public class AttackPoint : SaiBehaviour
{
    protected override void Reset()
    {
        base.Reset();
        transform.localPosition = new Vector3(0.046f, 0.507f, -0.01f);
    }
}

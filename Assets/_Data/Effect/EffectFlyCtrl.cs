using UnityEngine;

public abstract class EffectFlyCtrl : EffectCtrl
{
    [SerializeField] protected FlyToTarget flyToTarget;
    public FlyToTarget FlyToTarget => flyToTarget;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFlyToTarget();
    }

    protected virtual void LoadFlyToTarget()
    {
        if (this.flyToTarget != null) return;
        this.flyToTarget = GetComponentInChildren<FlyToTarget>();
        Debug.Log(transform.name + ": LoadFlyToTarget", gameObject);
    }
}

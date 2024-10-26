using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }

    protected override void OnDead()
    {
        this.ctrl.Despawn.DoDespawn();
    }

    protected override void OnHurt()
    {
        //throw new System.NotImplementedException();
    }
}

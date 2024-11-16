using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyCtrl ctrl;
    [SerializeField] protected CapsuleCollider capsuleCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
        this.LoadCapsuleCollider();
    }

    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        this.capsuleCollider.center = new Vector3(0, 1, 0);
        this.capsuleCollider.radius = 0.3f;
        this.capsuleCollider.height = 1.5f;
        this.capsuleCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCapsuleCollider", gameObject);
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }

    protected override void OnDead()
    {
        this.ctrl.Animator.SetBool("isDead", this.isDead);
        this.capsuleCollider.enabled = false;
        Invoke(nameof(this.DoDespawn), 5f);

        ItemDropSpawnerCtrl.Instance.DropMany(ItemCode.Gold, transform.position, 10);
        ItemDropSpawnerCtrl.Instance.Drop(ItemCode.Wand, transform.position, 1);
        InventoriesManager.Instance.AddItem(ItemCode.PlayerExp, 1);
    }

    protected virtual void DoDespawn()
    {
        this.ctrl.Despawn.DoDespawn();
    }

    protected override void OnHurt()
    {
        //throw new System.NotImplementedException();
    }

    protected override void Reborn()
    {
        base.Reborn();
        this.capsuleCollider.enabled = true;
    }
}

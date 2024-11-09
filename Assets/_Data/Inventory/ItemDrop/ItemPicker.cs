using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPicker : SaiBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.3f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null) return;
        ItemDropCtrl itemDropCtrl = other.transform.parent.GetComponent<ItemDropCtrl>();
        if (itemDropCtrl == null) return;
        itemDropCtrl.Despawn.DoDespawn();
    }
}

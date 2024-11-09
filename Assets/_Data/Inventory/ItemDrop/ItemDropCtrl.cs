using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ItemDropCtrl : PoolObj
{
    [SerializeField] protected Rigidbody _rigi;
    public Rigidbody Rigidbody => _rigi;

    [SerializeField] protected int dropCount = 0;
    public int DropCount => dropCount;

    public abstract ItemCode GetItemCode();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigi != null) return;
        this._rigi = GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }


    public override string GetName()
    {
        return this.GetItemCode().ToString();
    }


    public virtual void SetDropCount(int dropCount)
    {
        this.dropCount = dropCount;
    }
}

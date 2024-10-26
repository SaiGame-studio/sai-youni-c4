using UnityEngine;

public abstract class TowerAbstract : SaiBehaviour
{
    [Header("Tower")]
    [SerializeField] protected TowerCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<TowerCtrl>();
        Debug.Log(transform.name + ": LoadTowerCtrl", gameObject);
    }
}

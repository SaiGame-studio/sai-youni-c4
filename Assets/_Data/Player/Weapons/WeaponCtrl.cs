using UnityEngine;

public class WeaponCtrl : SaiBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform attackPoint;
    public Transform AttackPoint => attackPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadAttackPoint();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localPosition = new Vector3(0.108000003f, 0.0790000036f, 0.0170000009f);
        this.model.localRotation = Quaternion.Euler(new Vector3(349.246216f, 173.801498f, 283.948151f));
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadAttackPoint()
    {
        if (this.attackPoint != null) return;
        this.attackPoint = transform.Find("AttackPoint");
        Debug.Log(transform.name + ": LoadAttackPoint", gameObject);
    }
}

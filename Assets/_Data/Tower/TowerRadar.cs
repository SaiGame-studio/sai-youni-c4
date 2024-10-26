using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerRadar : SaiBehaviour
{
    [SerializeField] protected EnemyCtrl nearest;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigibody;
    [SerializeField] protected List<EnemyCtrl> enemies;

    protected virtual void FixedUpdate()
    {
        this.FindNearest();
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name, collider.gameObject);
        EnemyCtrl enemyCtrl = collider.GetComponentInParent<EnemyCtrl>();
        if (enemyCtrl == null) return;

        this.AddEnemy(enemyCtrl);
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        EnemyCtrl enemyCtrl = collider.GetComponentInParent<EnemyCtrl>();
        if (enemyCtrl == null) return;

        this.RemoveEnemy(enemyCtrl);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        //Not use in this project
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 12;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigibody != null) return;
        this._rigibody = GetComponent<Rigidbody>();
        this._rigibody.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void AddEnemy(EnemyCtrl enemyCtrl)
    {
        this.enemies.Add(enemyCtrl);
    }

    protected virtual void RemoveEnemy(EnemyCtrl enemyCtrl)
    {
        if (this.nearest == enemyCtrl) this.nearest = null;
        this.enemies.Remove(enemyCtrl);
    }

    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            enemyDistance = Vector3.Distance(transform.position, enemyCtrl.transform.position);
            if (enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearest = enemyCtrl;
            }
        }
    }

    public virtual EnemyCtrl GetTarget()
    {
        return this.nearest;
    }
}

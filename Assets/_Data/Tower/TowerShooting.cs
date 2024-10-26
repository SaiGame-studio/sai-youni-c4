using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [Header("Shooting")]
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected string bulletName = "Bullet";
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 0.5f;
    [SerializeField] protected int firePointIndex = 0;
    [SerializeField] protected List<FirePoint> firePoints = new();

    protected virtual void FixedUpdate()
    {
        this.GetTarget();
        this.LookAtTarget();
        this.Shooting();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFirePoints();
    }

    protected virtual void GetTarget()
    {
        this.target = this.ctrl.Radar.GetTarget();
    }

    protected virtual void LookAtTarget()
    {
        if (this.target == null) return;
        this.ctrl.Rotator.LookAt(this.target.transform.position);
    }

    protected virtual void Shooting()
    {
        this.timer += Time.deltaTime;
        if (this.target == null) return;
        if (this.timer < this.delay) return;
        this.timer = 0;

        FirePoint firePoint = this.GetFirePoint();

        EffectCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.bulletName);
        EffectCtrl newEfffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, firePoint.transform.position, firePoint.transform.rotation);
        newEfffect.gameObject.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        //int pointIndex = Random.Range(0,this.firePoints.Count);
        this.firePointIndex++;
        if (this.firePointIndex >= this.firePoints.Count) this.firePointIndex = 0;
        return this.firePoints[this.firePointIndex];
    }

     protected virtual void LoadFirePoints()
    {
        if (this.firePoints.Count > 0) return;
        FirePoint[] points = this.ctrl.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(points);
        Debug.LogWarning(transform.name + ": LoadFirePoints", gameObject);
    }
}

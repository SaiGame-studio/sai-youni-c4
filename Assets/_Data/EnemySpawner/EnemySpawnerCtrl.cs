using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : SaiSingleton<EnemySpawnerCtrl>
{
    [SerializeField] protected EnemySpawner spawner;
    public EnemySpawner Spawner => spawner;

    [SerializeField] protected EnemyPrefabs prefabs;
    public EnemyPrefabs Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<EnemySpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<EnemyPrefabs>();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
}

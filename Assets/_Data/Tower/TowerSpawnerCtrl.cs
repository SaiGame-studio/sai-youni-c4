using UnityEngine;

public class TowerSpawnerCtrl : SaiSingleton<TowerSpawnerCtrl>
{
    [SerializeField] protected TowerSpawner spawner;
    public TowerSpawner Spawner => spawner;

    [SerializeField] protected TowerPrefabs prefabs;
    public TowerPrefabs Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<TowerSpawner>();
        Debug.Log(transform.name + ": TowerSpawner", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<TowerPrefabs>();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

}

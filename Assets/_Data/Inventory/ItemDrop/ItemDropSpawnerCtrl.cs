using UnityEngine;

public class ItemDropSpawnerCtrl : SaiSingleton<ItemDropSpawnerCtrl>
{
    [SerializeField] protected ItemDropSpawner spawner;
    public ItemDropSpawner Spawner => spawner;

    [SerializeField] protected ItemDropPrefabs prefabs;
    public ItemDropPrefabs Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadEffectPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<ItemDropSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadEffectPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<ItemDropPrefabs>();
        Debug.Log(transform.name + ": LoadEffectPrefabs", gameObject);
    }

    public virtual ItemDropCtrl Drop(ItemCode itemCode, Vector3 position, int dropCount)
    {
        ItemDropCtrl prefab = this.Prefabs.GetByName(itemCode.ToString());
        ItemDropCtrl newObject = this.Spawner.Spawn(prefab, position);
        newObject.SetDropCount(dropCount);
        newObject.gameObject.SetActive(true);
        return newObject;
    }

    public virtual void DropMany(ItemCode itemCode, Vector3 dropPosition, int dropCount)
    {
        for (int i = 0; i < dropCount; i++)
        {
            this.Drop(itemCode, dropPosition, 1);
        }
    }
}

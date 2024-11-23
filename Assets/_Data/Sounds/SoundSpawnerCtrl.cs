using UnityEngine;

public class SoundSpawnerCtrl : SaiSingleton<SoundSpawnerCtrl>
{
    [SerializeField] protected SoundSpawner spawner;
    public SoundSpawner Spawner => spawner;

    [SerializeField] protected SoundPrefabs prefabs;
    public SoundPrefabs Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSoundPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<SoundSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadSoundPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<SoundPrefabs>();
        Debug.Log(transform.name + ": LoadSoundPrefabs", gameObject);
    }
}

using UnityEngine;

public class EffectSpawnerCtrl : SaiSingleton<EffectSpawnerCtrl>
{
    [SerializeField] protected EffectSpawner spawner;
    public EffectSpawner Spawner => spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<EffectSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }
}

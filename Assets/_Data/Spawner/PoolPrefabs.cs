using System.Collections.Generic;
using UnityEngine;

public abstract class PoolPrefabs<T> : SaiBehaviour where T : PoolObj
{
    [SerializeField] protected List<T> prefabs = new();

    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        foreach (T prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        foreach (Transform child in transform)
        {
            T classPrefab = child.GetComponent<T>();
            if (classPrefab != null) this.prefabs.Add(classPrefab);
        }
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    public virtual T GetRandom()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }

    public virtual T GetByName(string prefabName)
    {
        foreach (T prefab in this.prefabs)
        {
            if (prefab.name != prefabName) continue;
            return prefab;
        }

        return null;
    }
}

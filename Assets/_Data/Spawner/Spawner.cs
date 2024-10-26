using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : SaiBehaviour where T : PoolObj
{
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected List<T> inPoolObjs = new();

    public virtual T Spawn(T prefab)
    {
        T newObject = this.GetObjFromPool(prefab);
        if (newObject == null)
        {
            newObject = Instantiate(prefab);
            this.spawnCount++;
            this.UpdateName(prefab.transform, newObject.transform);
        }

        GetComponent<EnemyCtrl>();

        return newObject;
    }

    public virtual T Spawn(T prefab, Vector3 postion)
    {
        T newBullet = this.Spawn(prefab);
        newBullet.transform.position = postion;
        return newBullet;
    }

    public virtual T Spawn(T prefab, Vector3 postion, Quaternion rotation)
    {
        T newBullet = this.Spawn(prefab, postion);
        newBullet.transform.rotation = rotation;
        return newBullet;
    }

    public virtual void Despawn(T obj)
    {
        if (obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjectToPool(obj);
        }
    }

    protected virtual void AddObjectToPool(T obj)
    {
        this.inPoolObjs.Add(obj);
    }

    protected virtual void RemoveObjectFromPool(T obj)
    {
        this.inPoolObjs.Remove(obj);
    }

    protected virtual void UpdateName(Transform prefab, Transform newObject)
    {
        newObject.name = prefab.name + "_" + this.spawnCount;
    }

    protected virtual T GetObjFromPool(T prefab)
    {
        foreach (T inPoolObj in this.inPoolObjs)
        {
            if (prefab.GetName() == inPoolObj.GetName())
            {
                this.RemoveObjectFromPool(inPoolObj);
                return inPoolObj;
            }
        }

        return null;
    }
}

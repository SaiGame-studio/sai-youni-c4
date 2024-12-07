using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandBaiscCtrl : SaiBehaviour
{
    [SerializeField] protected Transform model;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localPosition = new Vector3(-0.0115999999f, 0.0759999976f, 0.0110999998f);
        this.model.localRotation = Quaternion.Euler(new Vector3(349.246216f, 173.801498f, 283.948151f));
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}

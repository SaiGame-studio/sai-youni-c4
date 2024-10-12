using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : SaiBehaviour
{
    [SerializeField] protected TowerRadar radar;
    public TowerRadar Radar => radar;

    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRadar();
        this.LoadRotator();
    }

    protected virtual void LoadRadar()
    {
        if (this.radar != null) return;
        this.radar = GetComponentInChildren<TowerRadar>();
        Debug.Log(transform.name + ": LoadRadar", gameObject);
    }

    protected virtual void LoadRotator()
    {
        if (this.rotator != null) return;
        this.rotator = transform.Find("Model").Find("Rotator");
        Debug.Log(transform.name + ": LoadRotator", gameObject);
    }
}

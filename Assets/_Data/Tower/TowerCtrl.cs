using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : SaiBehaviour
{
    [SerializeField] protected TowerRadar radar;
    public TowerRadar Radar => radar;

    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    [SerializeField] protected TowerShooting towerShooting;
    public TowerShooting TowerShooting => towerShooting;

    [SerializeField] protected LevelAbstract level;
    public LevelAbstract Level => level;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRadar();
        this.LoadRotator();
        this.LoadTowerShootings();
        this.LoadLevel();
    }

    protected virtual void LoadLevel()
    {
        if (this.level != null) return;
        this.level = GetComponentInChildren<LevelAbstract>();
        Debug.Log(transform.name + ": LoadLevel", gameObject);
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

    protected virtual void LoadTowerShootings()
    {
        if (this.towerShooting != null) return;
        this.towerShooting = GetComponentInChildren<TowerShooting>();
        Debug.Log(transform.name + ": LoadTowerShootings", gameObject);
    }
}

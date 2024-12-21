using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : SaiSingleton<TowerManager>
{
    [SerializeField] protected TowerCode newTowerId = TowerCode.NoTower;
    [SerializeField] protected TowerCtrl towerPrefab;
    [SerializeField] protected bool towerPlaced = false;

    protected virtual void Update()
    {
        this.ShowTowerToPlace();
    }

    protected virtual void ShowTowerToPlace()
    {
        if (this.towerPlaced) return;

        this.newTowerId = MapKeyCodeToTowerCode(InputHotkeys.Instance.KeyCode);

        if (this.newTowerId == TowerCode.NoTower)
        {
            if (this.towerPrefab != null) this.towerPrefab.SetActive(false);
            this.towerPrefab = null;
            return;
        }

        if (this.towerPrefab == null)
        {
            this.towerPrefab = this.GetTowerPrefab(this.newTowerId);
            if (this.towerPrefab == null) return;
            this.towerPrefab.TowerShooting.Disable();
            this.towerPrefab.SetActive(true);
        }

        this.towerPrefab.transform.position = PlayerCtrl.Instance.CrosshairPointer.transform.position;

        if (InputHotkeys.Instance.IsPlaceTower) this.PlaceTower();
    }

    protected virtual void PlaceTower()
    {
        this.towerPlaced = true;

        TowerCtrl newTower = this.Spawn(this.towerPrefab);
        newTower.TowerShooting.Active();
        newTower.SetActive(true);

        Invoke(nameof(this.PlaceFinish), 0.5f);
    }

    protected virtual void PlaceFinish()
    {
        this.towerPlaced = false;
    }

    protected virtual TowerCtrl GetTowerPrefab(TowerCode towerCode)
    {
        return TowerSpawnerCtrl.Instance.Prefabs.GetByName(towerCode.ToString());
    }

    protected virtual TowerCtrl Spawn(TowerCtrl prefab)
    {
        return TowerSpawnerCtrl.Instance.Spawner.Spawn(prefab, prefab.transform.position);
    }

    protected virtual TowerCode MapKeyCodeToTowerCode(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.Alpha1: return TowerCode.MachineGun;
            case KeyCode.Alpha2: return TowerCode.LaserGun;
            default: return TowerCode.NoTower;
        }
    }
}

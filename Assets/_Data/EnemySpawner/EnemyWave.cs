using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : SaiBehaviour
{
    [SerializeField] protected EnemySpawnerCtrl ctrl;
    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new();

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Spawning), this.spawnSpeed);
    }

    protected virtual void FixedUpdate()
    {
        this.RemoveDeadOne();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawnerCtrl();
    }

    protected virtual void LoadEnemySpawnerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponent<EnemySpawnerCtrl>();
        Debug.Log(transform.name + ": LoadEnemySpawnerCtrl", gameObject);
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);

        if (this.spawnedEnemies.Count >= this.maxSpawn) return;

        EnemyCtrl prefab = this.ctrl.Prefabs.GetRandom();
        EnemyCtrl newEnemy = this.ctrl.Spawner.Spawn(prefab, transform.position);
        newEnemy.gameObject.SetActive(true);
        this.spawnedEnemies.Add(newEnemy);
    }

    protected virtual void RemoveDeadOne()
    {
        foreach (EnemyCtrl enemyCtrl in this.spawnedEnemies)
        {
            if (enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                this.spawnedEnemies.Remove(enemyCtrl);
                return;
            }
        }
    }
}

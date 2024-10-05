using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<EnemyAbstractOld> enemies = new();
    EnemyAbstractOld minEnemy;
    EnemyAbstractOld maxEnemy;

    private void Start()
    {
        this.LoadEnemies();
        //this.ShowEnemies();
        //this.FindMinEnemy();
        //this.FindMaxEnemy();
    }

    protected void LoadEnemies()
    {
        foreach (Transform child in transform)
        {
            EnemyAbstractOld enemy = child.GetComponent<EnemyAbstractOld>();
            this.enemies.Add(enemy);
        }
    }

    protected void ShowEnemies()
    {
        foreach (EnemyAbstractOld enemy in this.enemies)
        {
            Debug.Log(enemy.name + " hp: " + enemy.GetHp() + " / isDead: " + enemy.IsDead());
        }
    }

    public List<EnemyAbstractOld> GetEnemies()
    {
        return this.enemies;
    }

    protected virtual void FindMinEnemy()
    {
        this.minEnemy = FindEnemyWithLowestHealth(this.enemies);

        if (minEnemy == null) Debug.Log("No Enemy.");
        else Debug.Log("Min: " + this.minEnemy.Health, this.minEnemy.gameObject);
    }

    protected virtual void FindMaxEnemy()
    {
        this.minEnemy = FindEnemyWithBiggestHealth(this.enemies);

        if (minEnemy == null) Debug.Log("No Enemy.");
        else Debug.Log("Min: " + this.minEnemy.Health, this.minEnemy.gameObject);
    }

    protected virtual EnemyAbstractOld FindEnemyWithBiggestHealth(List<EnemyAbstractOld> enemies)
    {
        //TODO:
        return null;
    }

    protected EnemyAbstractOld FindEnemyWithLowestHealth(List<EnemyAbstractOld> enemies)
    {
        if (enemies == null || enemies.Count == 0)
        {
            return null;
        }

        EnemyAbstractOld minEnemy = enemies[0];

        foreach (EnemyAbstractOld enemy in this.enemies)
        {
            if (enemy.Health < minEnemy.Health)
            {
                minEnemy = enemy;
            }
        }

        return minEnemy;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<EnemyAbstract> enemies = new();
    EnemyAbstract minEnemy;
    EnemyAbstract maxEnemy;

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
            EnemyAbstract enemy = child.GetComponent<EnemyAbstract>();
            this.enemies.Add(enemy);
        }
    }

    protected void ShowEnemies()
    {
        foreach (EnemyAbstract enemy in this.enemies)
        {
            Debug.Log(enemy.name + " hp: " + enemy.GetHp() + " / isDead: " + enemy.IsDead());
        }
    }

    public List<EnemyAbstract> GetEnemies()
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

    protected virtual EnemyAbstract FindEnemyWithBiggestHealth(List<EnemyAbstract> enemies)
    {
        //TODO:
        return null;
    }

    protected EnemyAbstract FindEnemyWithLowestHealth(List<EnemyAbstract> enemies)
    {
        if (enemies == null || enemies.Count == 0)
        {
            return null;
        }

        EnemyAbstract minEnemy = enemies[0];

        foreach (EnemyAbstract enemy in this.enemies)
        {
            if (enemy.Health < minEnemy.Health)
            {
                minEnemy = enemy;
            }
        }

        return minEnemy;
    }

}

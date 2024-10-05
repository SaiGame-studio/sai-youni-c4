using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySorting : MonoBehaviour
{
    public EnemyManager enemyManager;
    List<EnemyAbstractOld> sortEnemies = new();

    protected void Start()
    {
        //Invoke(nameof(this.Sorting), 2f);
    }

    protected void Sorting()
    {
        this.sortEnemies = new List<EnemyAbstractOld>(this.enemyManager.GetEnemies());

        this.PrintEnemyList(this.sortEnemies);
        //this.SelectionSort(this.sortEnemies);
        this.sortEnemies.Sort((enemy1, enemy2) => enemy1.Health.CompareTo(enemy2.Health));
        this.PrintEnemyList(this.sortEnemies);
    }

    void SelectionSort(List<EnemyAbstractOld> enemies)
    {
        for (int i = 0; i < enemies.Count - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < enemies.Count; j++)
            {
                if (enemies[j].Health < enemies[minIdx].Health)
                {
                    minIdx = j;
                }
            }

            EnemyAbstractOld temp = enemies[minIdx];
            enemies[minIdx] = enemies[i];
            enemies[i] = temp;
        }
    }

    void PrintEnemyList(List<EnemyAbstractOld> enemies)
    {
        Debug.Log("= Print ===================");

        foreach (var enemy in enemies)
        {
            Debug.Log(enemy.name + " - HP: " + enemy.Health);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbstract : MonoBehaviour
{
    string enemyName = "Zombie";
    int enemyHPCurrent = 100;
    public int Health => enemyHPCurrent;
    int enemyHPMax = 100;
    bool isDead = true;
    int minHealth = 0;
    int maxHealth = 100;

    private void Awake()
    {
        this.RandomHp();
    }

    public bool IsDead()
    {
        if (this.enemyHPCurrent <= 0) this.isDead = true;
        else this.isDead = false;

        return this.isDead;
    }

    public int GetHp()
    {
        return this.enemyHPCurrent;
    }

    public int SetHp(int newHp)
    {
        this.enemyHPCurrent = newHp;
        return this.enemyHPCurrent;
    }

    protected void RandomHp()
    {
        int newHp = Random.Range(this.minHealth, this.maxHealth + 1);
        this.SetHp(newHp);
    }
}

using UnityEngine;

public abstract class DamageReceiver : SaiBehaviour
{
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected int maxHP = 10;

    public virtual void Receive(int damage, DamageSender damageSender)
    {
        this.currentHP -= damage;
    }
}

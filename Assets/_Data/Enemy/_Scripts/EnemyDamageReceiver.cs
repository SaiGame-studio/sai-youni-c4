using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        Destroy(transform.parent.gameObject);
    }

    protected override void OnHurt()
    {
        //throw new System.NotImplementedException();
    }
}

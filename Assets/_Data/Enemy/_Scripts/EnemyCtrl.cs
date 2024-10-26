using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : PoolObj
{
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    public EnemyDamageReceiver EnemyDamageReceiver => enemyDamageReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAgent();
        this.LoadAnimator();
        this.LoadEnemyDamageReceiver();
    }

    protected virtual void LoadAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.Log(transform.name + ": LoadAgent", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.Find("Model").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadEnemyDamageReceiver()
    {
        if (this.enemyDamageReceiver != null) return;
        this.enemyDamageReceiver = GetComponentInChildren<EnemyDamageReceiver>();
        Debug.Log(transform.name + ": LoadEnemyDamageReceiver", gameObject);
    }
}

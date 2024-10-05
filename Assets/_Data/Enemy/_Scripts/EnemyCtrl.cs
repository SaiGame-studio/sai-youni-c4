using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : SaiBehaviour
{
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAgent();
        this.LoadAnimator();
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
        //this.animator = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
}

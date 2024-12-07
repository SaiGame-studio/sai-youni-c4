using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToTarget : SaiBehaviour
{
    protected Transform target;
    [SerializeField] protected float speed = 34f;

    protected void Update()
    {
        this.Flying();
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
        transform.parent.LookAt(target);
    }

    protected virtual void Flying()
    {
        if (this.target == null) return;
        transform.parent.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}

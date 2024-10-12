using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : SaiBehaviour
{
    public float speed = 10f;

    protected virtual void Update()
    {
        this.Moving();
    }

   protected virtual void Moving()
    {
        transform.parent.Translate(Vector3.forward * this.speed * Time.deltaTime);
    }
}

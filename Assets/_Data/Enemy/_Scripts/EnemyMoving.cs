using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    public Transform targetToMove;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        this.agent.SetDestination(this.targetToMove.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

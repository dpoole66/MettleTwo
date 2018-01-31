using System;
using UnityEngine;


[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof (ThirdPersonMettle))]
public class AIMettleControl : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }             
    public ThirdPersonMettle character { get; private set; } 
    private Transform target;


    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonMettle>();

	    agent.updateRotation = false;
	    agent.updatePosition = true;
    }

    private void Update()
    {

        if (target != null)
            agent.SetDestination(target.position);

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}


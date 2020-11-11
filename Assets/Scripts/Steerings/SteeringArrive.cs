using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringArrive : SteeringBase
{
    public float arrivalDistance = 0.3f;
    public float slowDownDistance;
    public GameObject target;
    protected Vector3 desiredVelocity;
    protected float maxSpeed;
    protected Movement agentMovement;

    private void Start()
    {
        agentMovement = GetComponent<Movement>();
        maxSpeed = agentMovement.maxSpeed;
    }

    public override Vector3 Force()
    {
        Vector3 remaining = target.transform.position - transform.position;
        remaining.y = 0f;
        float remainingDistance = remaining.magnitude;
        Vector3 forceReturned = Vector3.zero;

        if(remainingDistance > slowDownDistance)
        {
            desiredVelocity = remaining.normalized * maxSpeed;
            forceReturned = desiredVelocity - agentMovement.velocity;
        }
        else
        {
            desiredVelocity = remaining - agentMovement.velocity;
            forceReturned = desiredVelocity - agentMovement.velocity;
        }

        return forceReturned;
    }
}

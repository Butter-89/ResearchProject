using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringSeek : SteeringBase
{
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
        desiredVelocity = (target.transform.position - transform.position).normalized * maxSpeed;
        desiredVelocity.y = 0;
        return desiredVelocity - agentMovement.velocity;
    }
}

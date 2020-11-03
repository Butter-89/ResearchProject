using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringSeek : SteeringBase
{
    public GameObject target;
    private Vector3 desiredVelocity;
    private float maxSpeed;
    private Movement agentMovement;

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

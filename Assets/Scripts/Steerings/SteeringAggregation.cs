using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringAggregation : SteeringBase
{
    private Vector3 desiredVelocity;
    private Movement agentMovement;
    private float maxSpeed;

    private void Start()
    {
        agentMovement = GetComponent<Movement>();
        maxSpeed = agentMovement.maxSpeed;
    }

    public override Vector3 Force()
    {
        Vector3 steeringForce = Vector3.zero;
        Vector3 averageCenter = Vector3.zero;
        int count = 0;
        AgentSight sight = GetComponent<AgentSight>();
        for(int i = 0; i < sight.neighbors.Count; i++)
        {
            if(sight.neighbors[i] != this.gameObject)
            {
                averageCenter += sight.neighbors[i].transform.position;
                count++;
            }
        }

        if(count>0)
        {
            averageCenter /= count;
            desiredVelocity = (averageCenter - transform.position).normalized * maxSpeed;
            steeringForce = desiredVelocity - agentMovement.velocity;
        }
        return steeringForce;
    }
}

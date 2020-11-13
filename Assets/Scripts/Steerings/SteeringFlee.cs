using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringFlee : SteeringBase
{
    public GameObject target;
    public float alertDistance;
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
        if (target == null) return Vector3.zero;

        desiredVelocity = (transform.position - target.transform.position).normalized * maxSpeed;
        desiredVelocity.y = 0;
        if (Vector3.Distance(target.transform.position, transform.position) >= alertDistance)
            return Vector3.zero;
        else
            return desiredVelocity - agentMovement.velocity;
    }
}

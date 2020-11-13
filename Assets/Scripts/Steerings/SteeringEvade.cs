using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringEvade : SteeringBase
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
        if (target.GetComponent<Movement>() == null)
            throw new System.Exception("Target chased does not have Movement script attached");

        if (target == null) return Vector3.zero;

        Vector3 toTarget = target.transform.position - transform.position;
        toTarget.y = 0f;

        Vector3 targetVelocity = target.GetComponent<Movement>().velocity;

        float timeAhead = toTarget.magnitude / (maxSpeed + targetVelocity.magnitude);
        Vector3 expectedPosition = target.transform.position + targetVelocity * timeAhead;
        desiredVelocity = (transform.position - expectedPosition).normalized * maxSpeed;
        Vector3 forceReturned = desiredVelocity - agentMovement.velocity;

        return forceReturned;
    }
}

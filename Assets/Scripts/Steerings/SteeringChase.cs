using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringChase : SteeringBase
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
        if(target.GetComponent<Movement>() == null)
            throw new System.Exception("Target chased does not have Movement script attached");

        if (target == null) return Vector3.zero;

        Vector3 toTarget = target.transform.position - transform.position;
        toTarget.y = 0f;
        float relativeDirection = Vector3.Dot(transform.forward, target.transform.forward);
        if(Vector3.Dot(toTarget, transform.forward) > 0)
        {
            desiredVelocity = (target.transform.position - transform.position).normalized * maxSpeed;
            return desiredVelocity - agentMovement.velocity;
        }

        Vector3 targetVelocity = target.GetComponent<Movement>().velocity;

        float timeAhead = toTarget.magnitude / (maxSpeed + targetVelocity.magnitude);
        Vector3 expectedPosition = target.transform.position + targetVelocity * timeAhead;
        desiredVelocity = (expectedPosition - transform.position).normalized * maxSpeed;
        Vector3 forceReturned = desiredVelocity - agentMovement.velocity;

        return forceReturned;
    }
}

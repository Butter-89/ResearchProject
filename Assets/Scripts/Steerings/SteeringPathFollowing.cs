using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringPathFollowing : SteeringArrive
{
    public List<GameObject> nodes = new List<GameObject>();

    private int nodeNumber;
    //private float arrivalDistance = 5;
    private int nodeQty;    // number of nodes in the list
    private Vector3 force;

    void Start()
    {
        nodeQty = nodes.Count;
        nodeNumber = 0;
        target = nodes[0];

        agentMovement = GetComponent<Movement>();
        maxSpeed = agentMovement.maxSpeed;
        
    }

    public override Vector3 Force()
    {
        force = Vector3.zero;
        Vector3 toCurrentNode = target.transform.position - transform.position;
        toCurrentNode.y = 0;
        if(nodeNumber == nodeQty - 1)
        {
            return base.Force();
        }
        else
        {
            if(toCurrentNode.magnitude < arrivalDistance)
            {
                nodeNumber++;
                target = nodes[nodeNumber];
            }
            desiredVelocity = toCurrentNode.normalized * maxSpeed;
            force = desiredVelocity - agentMovement.velocity;
        }

        return force;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringSeparation : SteeringBase
{
    public float minDistance = 1;
    public float repulsionScale = 2; // the multiplier applied when two agents are within minDistance


    public override Vector3 Force()
    {
        Vector3 steeringForce = Vector3.zero;
        AgentSight sight = GetComponent<AgentSight>();
        foreach(GameObject neighbor in sight.neighbors)
        {
            if(neighbor && neighbor != this.gameObject)
            {
                Vector3 toNeighbor = neighbor.transform.position - transform.position;
                steeringForce += -toNeighbor.normalized / toNeighbor.magnitude;
                if (toNeighbor.magnitude < minDistance)
                    steeringForce *= repulsionScale;
            }
        }
        return steeringForce;
    }
}

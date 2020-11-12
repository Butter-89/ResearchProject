using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringAlignment : SteeringBase
{
    public override Vector3 Force()
    {
        Vector3 averageDirection = Vector3.zero;
        int count = 0;
        AgentSight sight = GetComponent<AgentSight>();

        for(int i = 0; i < sight.neighbors.Count; i++)
        {
            if(sight.neighbors[i] != this.gameObject)
            {
                averageDirection += sight.neighbors[i].transform.forward;
                count++;
            }
        }

        if(count > 0)
            averageDirection /= count;

        return averageDirection - transform.forward;
    }

}

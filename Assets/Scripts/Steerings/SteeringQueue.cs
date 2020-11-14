using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringQueue : SteeringBase
{
    public float max_queueAhead;
    public float max_queueRadius;
    public LayerMask layersChecked;

    private Collider[] colliders;
    private Movement agentMovement;
    private int layerID;
    private LayerMask layerMask;

    void Start()
    {
        agentMovement = GetComponent<Movement>();
        layerID = LayerMask.NameToLayer("Agents");
        layerMask = 1 << layerID;
    }

    public override Vector3 Force()
    {
        Vector3 velocity = agentMovement.velocity;
        Vector3 normalizedVelocity = velocity.normalized;
        Vector3 ahead = transform.position + normalizedVelocity * max_queueAhead;
        colliders = Physics.OverlapSphere(ahead, max_queueRadius, layerMask);
        if(colliders.Length > 0)
        {
            foreach(Collider c in colliders)
            {
                if(c.gameObject != this.gameObject && c.gameObject.GetComponent<Movement>().velocity.magnitude < velocity.magnitude)
                {
                    agentMovement.velocity *= 0.8f;
                    break;
                }
            }
        }

        return Vector3.zero;
    }
}

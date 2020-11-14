using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringQueueAvoidObstacle : SteeringBase
{
    public float avoidanceForce;
    public float max_sightForward;

    private Vector3 desiredVelocity;
    private Movement agentMovement;
    private float maxSpeed;
    private float maxForce;
    private GameObject[] obstacles;
    private int layerID;
    private LayerMask layerMask;

    void Start()
    {
        agentMovement = GetComponent<Movement>();
        maxSpeed = agentMovement.maxSpeed;
        maxForce = agentMovement.maxForce;
        if (avoidanceForce > maxForce)
            avoidanceForce = maxForce;

        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        layerID = LayerMask.NameToLayer("Obstacle");
        layerMask = 1 << layerID;
    }

    public override Vector3 Force()
    {
        RaycastHit hit;
        Vector3 force = Vector3.zero;
        Vector3 velocity = agentMovement.velocity;
        Vector3 normalizedVelocity = velocity.normalized;
        if(Physics.Raycast(transform.position, normalizedVelocity, out hit, max_sightForward, layerMask))
        {
            Vector3 ahead = transform.position + normalizedVelocity * max_sightForward;
            force = ahead - hit.collider.transform.position;
            force *= avoidanceForce;
            force.y = 0;
        }
        return force;
    }
}

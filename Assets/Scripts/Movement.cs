using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 10;
    public float maxForce = 100;
    public float interval = 0.2f;
    public float agentRadius = 1f;
    public float damping = 0.9f;
    public Vector3 velocity;
    public Vector3 steeringForce;
    public Transform destination;

    private Vector3 acceleration;
    private float timer;

    private SteeringBase[] steerings;

    private void Start()
    {
        steeringForce = Vector3.zero;
        timer = 0f;
        steerings = GetComponents<SteeringBase>();

    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            CalculateSteering();
        }

    }

    private void FixedUpdate()
    {
        CalculateVelocity();
        
    }

    private void CalculateSteering()
    {
        steeringForce = Vector3.zero;
        for(int i = 0; i < steerings.Length; i++)
        {
            steeringForce += steerings[i].Force();
        }
    }

    private void CalculateVelocity()
    {
        acceleration = steeringForce;
        velocity += acceleration * Time.fixedDeltaTime;
        if (velocity.magnitude > maxSpeed)
            velocity = velocity.normalized * maxSpeed;

        transform.position += velocity * Time.fixedDeltaTime;
        if(velocity.magnitude != 0)
            transform.forward = velocity.normalized;
    }
}

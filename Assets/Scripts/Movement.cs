using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 10;
    public float maxForce = 100;
    public Vector3 velocity;
    public float interval = 0.2f;
    public Vector3 steeringForce;
    public Transform destination;
    private Vector3 acceleration;
    private float timer;

    private List<SteeringBase> steerings;

    private void Start()
    {
        steeringForce = Vector3.zero;
        timer = 0f;
        SteeringBase[] steeringComp = GetComponents<SteeringBase>();
        foreach(SteeringBase sb in steeringComp)
        {
            steerings.Add(sb);
        }
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
        foreach(SteeringBase sb in steerings)
        {
            steeringForce += sb.Force();
        }
    }

    private void CalculateVelocity()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        if (velocity.magnitude > maxSpeed)
            velocity = velocity.normalized * maxSpeed;

        transform.position += velocity * Time.fixedDeltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedFormation : MonoBehaviour
{
    // Pre-defined formation in prefab
    public GameObject leader;
    public List<GameObject> members = new List<GameObject>();
    public float mobilityScale = 1;

    public List<Vector3> relativePositions = new List<Vector3>();

    private void Start()
    {
        leader = this.gameObject;
        Movement[] agentMovementComps = GetComponentsInChildren<Movement>();
        foreach(Movement agentMovement in agentMovementComps)
        {
            GameObject agent = agentMovement.transform.gameObject;
            members.Add(agent);
            Vector3 relativePosition = agent.transform.position - transform.position;

            if(agent.GetComponent<SteeringArrive>() == null)
                agent.AddComponent<SteeringArrive>();
        }
    }

    
    
}

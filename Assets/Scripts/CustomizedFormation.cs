using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedFormation : MonoBehaviour
{
    // Pre-defined formation in prefab
    public GameObject target;
    public List<GameObject> members = new List<GameObject>();
    public float mobilityScale = 1;

    public List<Vector3> relativePositions = new List<Vector3>();

    private void Start()
    {
        Movement[] agentMovementComps = GetComponentsInChildren<Movement>();
        foreach(Movement agentMovement in agentMovementComps)
        {
            GameObject agent = agentMovement.transform.gameObject;
            members.Add(agent);
            Vector3 relativePosition = agent.transform.position - transform.position;
            relativePositions.Add(relativePosition);
            if(agent.GetComponent<SteeringArrive>() == null)
                agent.AddComponent<SteeringArrive>();
        }

        
        SetMemberDestination();
    }

    private void SetMemberDestination()
    {
        for(int i = 0; i < members.Count; i++)
        {
            members[i].GetComponent<SteeringArrive>().targetPosition = target.transform.position + relativePositions[i];
        }
    }
    
}

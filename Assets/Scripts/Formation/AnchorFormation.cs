using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorFormation : MonoBehaviour
{
    /*  Should be applied on a Squad object.
        Move the squad object and let the agents move towards the updatedposition    */
    public bool loadData;
    public FormationData formationData;
    public float interval = 3;
    public List<GameObject> squadMembers = new List<GameObject>();
    private List<Vector3> positions = new List<Vector3>();    
    private List<GameObject> anchors = new List<GameObject>();

    void Start()
    {
        Movement[] agentMovementComps = GetComponentsInChildren<Movement>();
        for(int i = 0; i < squadMembers.Count; i++)
        {
            GameObject agent = squadMembers[i];
            if (agent.GetComponent<SteeringArrive>() == null)
                agent.AddComponent<SteeringArrive>();

            agent.GetComponent<Movement>().UpdateSteerings();
            agent.GetComponent<SteeringArrive>().slowDownDistance = 4f;
            // TODO: Automatically generate the positions according to the formType
            if (!loadData)
                positions.Add(agent.transform.position - transform.position);   // origin as the anchor point
            else
            {
                positions.Add(formationData.positions[i] * interval);
            }

            //agent.transform.parent = this.transform;
            GameObject anchor = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            anchor.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            anchor.transform.parent = this.transform;
            //anchor.transform.localPosition = Vector3.zero;
            anchor.transform.name = "GridPoint ";
            if(!loadData)
                anchor.transform.localPosition = transform.InverseTransformPoint(agent.transform.position);
            else
                anchor.transform.localPosition = positions[i];

            anchors.Add(anchor);
        }
    }

    private void FixedUpdate()
    {
        // Update the members' target positions
        for (int i = 0; i < squadMembers.Count; i++)
        {
            squadMembers[i].GetComponent<SteeringArrive>().targetPosition = anchors[i].transform.position;
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}

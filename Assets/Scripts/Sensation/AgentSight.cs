using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSight : MonoBehaviour
{
    public float sightRadius = 10f;
    public float scanInterval = 0.3f;
    public List<GameObject> neighbors;
    public LayerMask layersChecked;

    private float timer = 0f;
    private Collider[] detectedColliders;

    void Start()
    {
        neighbors = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer >= scanInterval)
        {
            neighbors.Clear();
            detectedColliders = Physics.OverlapSphere(transform.position, sightRadius, layersChecked);
            for(int i = 0; i < detectedColliders.Length; i++)
            {
                if (detectedColliders[i].GetComponent<Movement>())
                    neighbors.Add(detectedColliders[i].gameObject);
            }
            timer = 0f;
        }
    }
}

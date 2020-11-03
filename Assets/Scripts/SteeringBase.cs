using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBase : MonoBehaviour
{
    public float weight = 1;
    public virtual Vector3 Force()
    {
        return Vector3.zero;
    }
}

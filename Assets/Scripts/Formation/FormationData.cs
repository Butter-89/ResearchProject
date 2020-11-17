using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FormationData", order = 1)]
public class FormationData : ScriptableObject
{
    public List<Vector3> positions;
}

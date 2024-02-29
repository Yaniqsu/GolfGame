using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class GroundGenerationSettings : ScriptableObject
{
    public int groundWidth;
    public Vector3 startingPos;
    public GameObject t_ground;
    public GameObject t_hole;
}

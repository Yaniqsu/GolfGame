using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBetween : MonoBehaviour
{
    [SerializeField] Vector3 pointA;
    [SerializeField] Vector3 pointB;
    [SerializeField, Range(0f, 1f)] float minInterpolation;
    [SerializeField, Range(0f, 1f)] float maxInterpolation;

    public void SetPosition()
    {
        transform.position = Vector3.Lerp(pointA, pointB, SetInterpolation());
    }
    float SetInterpolation()
    {
        return Random.Range(minInterpolation, maxInterpolation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pointA, pointB);
    }
}

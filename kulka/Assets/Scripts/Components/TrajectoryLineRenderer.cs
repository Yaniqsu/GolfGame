using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLineRenderer : MonoBehaviour
{
    public ObjectPool dots;
    List<Vector3> pointsOnLine = new();
    GameObject tmp;

    public void DrawTrajectory(Vector3 startingPosition, Vector3 startingVelocity, Rigidbody2D rb, float minHeight)
    {
        GeneratePointsOnLine(startingPosition, startingVelocity, rb, minHeight);
        PositionDots();
    }
    void GeneratePointsOnLine(Vector3 startingPosition, Vector3 startingVelocity, Rigidbody2D rb, float minHeight)
    {
        pointsOnLine.RemoveRange(0, pointsOnLine.Count);
        float timeUntilReachingGround = TrajectoryCalculator.GetTimeUntilReachingY(startingPosition, startingVelocity, rb, minHeight);
        for(int i = 1; i <= dots.PoolSize; i++)
        {
            pointsOnLine.Add(TrajectoryCalculator.CalculatePoint(
                startingPosition, startingVelocity, rb, Mathf.Lerp(0, timeUntilReachingGround, (float)i / (float)dots.PoolSize))
                );
        }
    }
    void PositionDots()
    {
        for (int i = 0; i < pointsOnLine.Count; i ++)
        {
            tmp = dots.GetObjectAt(i);
            tmp.transform.position = pointsOnLine[i];
        }
    }
}

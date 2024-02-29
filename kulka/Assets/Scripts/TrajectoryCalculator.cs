using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrajectoryCalculator
{
    public static Vector3 CalculatePoint(Vector3 startPosition, Vector3 startVelocity, Rigidbody2D rb, float time)
    {
        return rb.drag == 0 ?
            CalculatePointWithoutDrag(startPosition, startVelocity, time)
            : CalculatePointWithDrag(startPosition, startVelocity, rb, time);
    }

    static Vector3 CalculatePointWithoutDrag(Vector3 startPosition, Vector3 startVelocity, float time)
    {
        Vector3 acceleration = Physics2D.gravity;
        Vector3 position = startPosition;

        return position + startVelocity * time + 0.5f * acceleration * time * time;
    }
    static Vector3 CalculatePointWithDrag(Vector3 startPosition, Vector3 startVelocity, Rigidbody2D rb, float time)
    {
        Vector3 acceleration = Physics2D.gravity;
        Vector3 position = startPosition;

        float frameDrag = 1.0f - rb.drag * Time.fixedDeltaTime;
        float frames = time / Time.fixedDeltaTime;

        float frameDragLog = (float)Mathf.Log(frameDrag);
        float frameDragPower = Mathf.Pow(frameDrag, frames);

        position += startVelocity * ((frameDragPower - 1.0f) / frameDragLog) * Time.fixedDeltaTime;

        float accDragFactor = (rb.drag * Time.fixedDeltaTime - 1);
        accDragFactor *= (frameDragPower - frames * frameDragLog - 1.0f);
        accDragFactor /= (rb.drag * frameDragLog);

        position += acceleration * accDragFactor * Time.fixedDeltaTime;

        return position;
    }


    public static float GetTimeUntilReachingY(Vector3 startPosition, Vector3 startVelocity, Rigidbody2D rb, float targetY)
    {
        Vector3 currentPos;

        float time = 0;
        float accuracy = 0.001f;

        while(true)
        {
            currentPos = CalculatePoint(startPosition, startVelocity, rb, time);
            if (currentPos.y < targetY + startPosition.y)
                break;
            time += accuracy;
        }

        return time;
    }
}

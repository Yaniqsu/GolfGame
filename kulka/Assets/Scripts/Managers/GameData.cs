using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static int highScore { get; private set; } = 0;
    public static int currentScore { get; private set; }

    public static void IncreaseScore()
    {
        currentScore++;
        if (currentScore > highScore)
            highScore = currentScore;
    }

    public static void ReseScore()
    {
        currentScore = 0;
    }
}

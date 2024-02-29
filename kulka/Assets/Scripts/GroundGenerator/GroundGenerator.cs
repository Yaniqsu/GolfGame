using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public static void GenerateGround(GroundGenerationSettings settings)
    {
        List<TileData> tiles = GroundBuilder.GenerateGround(settings);
        foreach (TileData t in tiles)
        {
            Instantiate(t.tile, t.position, Quaternion.identity);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class GroundBuilder
{
    public static List<TileData> GenerateGround(GroundGenerationSettings settings)
    {
        List<TileData> tiles = new();

        InitializeTilesList(ref tiles, settings.groundWidth);

        int groundMidPoint = Mathf.CeilToInt(settings.groundWidth / 2);

        int groundPointWithHole = Random.Range(groundMidPoint, settings.groundWidth - 2);

        tiles[groundPointWithHole] = new TileData(settings.startingPos + Vector3.right * groundPointWithHole, settings.t_hole);

        for(int i = 0; i < groundPointWithHole; i++)
        {
            tiles[i] = new TileData(settings.startingPos + Vector3.right * i, settings.t_ground);
        }

        for (int i = groundPointWithHole + 1; i < tiles.Count; i++)
        {
            tiles[i] = new TileData(settings.startingPos + Vector3.right * i, settings.t_ground);
        }

        return tiles;
    }
    private static void InitializeTilesList(ref List<TileData> tiles, int length)
    {
        for(int i = 0; i < length; i++)
        {
            tiles.Add(new TileData());
        }
    }
}

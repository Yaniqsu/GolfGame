using UnityEngine;

public class TileData
{
    public Vector3 position;
    public GameObject tile;

    public TileData()
    {
        position = Vector3.zero;
        tile = null;
    }
    public TileData(Vector3 position, GameObject tile)
    {
        this.position = position;
        this.tile = tile;
    }
}

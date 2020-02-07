using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public enum TileType
    {
        Wall, Road, Obstacle
    }

    public static readonly int Width = 256;
    public static readonly int Height = 256;

    public TileType type = TileType.Wall;
    public bool isPoliceBegin = false;
    public bool isThiefBegin = false;
    public bool isEnd = false;

    public TileType GetType()
    {
        return type;
    }
}

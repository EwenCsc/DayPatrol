using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    Block[,] tiles;

    [SerializeField] Sprite map = null;

    [SerializeField] Sprite straightRoad = null;
    [SerializeField] Sprite wall = null;
    void Start()
    {
        tiles = new Block[(int)map.rect.width, (int)map.rect.height];
        Debug.Log(tiles.Length);
        Texture2D texture = map.texture;

        GameObject prt = new GameObject("Tiles");
        prt.transform.position = Vector3.zero;
        Vector3 offset = new Vector3(map.rect.width / 2 * Block.Width / 100f, map.rect.height / 2 * Block.Height / 100f);
        for (int i = 0; i < map.rect.width; i++)
        {
            for (int j = 0; j < map.rect.height; j++)
            {
                Color col = texture.GetPixel(i, j);
                GameObject obj = new GameObject("Tile" + i + "" + j);
                obj.transform.parent = prt.transform;

                obj.transform.position = new Vector3(i * Block.Width / 100f, j * Block.Height / 100f) - offset;
                tiles[i, j] = obj.AddComponent<Block>();
                if (col == Color.red)
                {
                    tiles[i, j].type = Block.TileType.Wall;
                    obj.AddComponent<SpriteRenderer>().sprite = wall;
                }
                else if (col == Color.black)
                {
                    tiles[i, j].type = Block.TileType.Road;
                    obj.AddComponent<SpriteRenderer>().sprite = straightRoad;
                }
            }
        }
    }
}

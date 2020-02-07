using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Block[,] blocks;

    [SerializeField] Sprite map = null;

    [SerializeField] GameObject roadPrefab = null;
    [SerializeField] GameObject wallPrefab = null;
    [SerializeField] GameObject trottoir = null;
    [SerializeField] GameObject extAngle = null;
    [SerializeField] GameObject intAngle = null;
    [SerializeField] GameObject obstaclePrefab = null;
    [SerializeField] GameObject[] buildingsPrefab = null;
    public void Init()
    {
        blocks = new Block[(int)map.rect.width, (int)map.rect.height];
        Texture2D texture = map.texture;

        GameObject prt = new GameObject("Blocks");
        prt.transform.position = Vector3.zero;
        Vector3 offset = new Vector3(map.rect.width / 2 * Block.Width, 0, map.rect.height / 2 * Block.Height);
        offset = Vector3.zero;
        for (int i = 0; i < map.rect.width; i++)
        {
            for (int j = 0; j < map.rect.height; j++)
            {
                Color col = texture.GetPixel(i, j);
                //Road
                if (col == new Color(139f / 255f, 139f / 255f, 139f / 255f) || col == new Color(1, 214f / 255f, 0))
                {
                    blocks[i, j] = Instantiate(roadPrefab, new Vector3(i, 0, j) + offset, Quaternion.identity, prt.transform).GetComponent<Block>();
                    blocks[i, j].gameObject.isStatic = true; 
                }
                else if (col == new Color(0, 0, 1))
                {
                    blocks[i, j] = Instantiate(roadPrefab, new Vector3(i, 0, j) + offset, Quaternion.identity, prt.transform).GetComponent<Block>();
                    blocks[i, j].isEnd = true;
                    blocks[i, j].gameObject.isStatic = true;
                }
                else if (col == Color.cyan)
                {
                    blocks[i, j] = Instantiate(roadPrefab, new Vector3(i, 0, j) + offset, Quaternion.identity, prt.transform).GetComponent<Block>();
                    blocks[i, j].isPoliceBegin = true;
                    blocks[i, j].gameObject.isStatic = true;
                }
                else if (col == Color.green)
                {
                    blocks[i, j] = Instantiate(roadPrefab, new Vector3(i, 0, j) + offset, Quaternion.identity, prt.transform).GetComponent<Block>();
                    blocks[i, j].isThiefBegin = true;
                    blocks[i, j].gameObject.isStatic = true;
                }


                else if (col == new Color(123.0f / 255.0f, 123.0f / 255.0f, 123.0f / 255.0f))
                {
                    blocks[i, j] = Instantiate(trottoir, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, 90, 0), prt.transform).GetComponent<Block>();
                }
                else if (col == new Color(86.0f / 255.0f, 86.0f / 255.0f, 86.0f / 255.0f))
                {
                    blocks[i, j] = Instantiate(trottoir, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, -90, 0), prt.transform).GetComponent<Block>();
                }
                else if (col == new Color(201.0f / 255.0f, 201.0f / 255.0f, 201.0f / 255.0f))
                {
                    blocks[i, j] = Instantiate(trottoir, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, 180, 0), prt.transform).GetComponent<Block>();
                }
                else if (col == new Color(101.0f / 255.0f, 101.0f / 255.0f, 101.0f / 255.0f))
                {
                    blocks[i, j] = Instantiate(trottoir, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, 0, 0), prt.transform).GetComponent<Block>();
                }
                else if (col == Color.red)
                {
                    blocks[i, j] = Instantiate(extAngle, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, 0, 0), prt.transform).GetComponent<Block>();
                }
                else if (col == new Color(204.0f / 255.0f, 0, 0))
                {
                    blocks[i, j] = Instantiate(extAngle, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, 90, 0), prt.transform).GetComponent<Block>();
                }
                else if (col == new Color(146.0f / 255.0f, 0, 0))
                {
                    blocks[i, j] = Instantiate(extAngle, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, -90, 0), prt.transform).GetComponent<Block>();
                }
                else if (col == new Color(107.0f / 255.0f, 0, 0))
                {
                    blocks[i, j] = Instantiate(extAngle, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, 180, 0), prt.transform).GetComponent<Block>();
                }
                else if (col == new Color(0, 131.0f / 255.0f, 1))
                {
                    blocks[i, j] = Instantiate(intAngle, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, 0, 0), prt.transform).GetComponent<Block>();
                }
                else if (col == new Color(0, 102.0f / 255.0f, 199.0f / 255.0f))
                {
                    blocks[i, j] = Instantiate(intAngle, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, 180, 0), prt.transform).GetComponent<Block>();
                }
                else if (col == new Color(0, 89.0f / 255.0f, 174.0f / 255.0f))
                {
                    blocks[i, j] = Instantiate(intAngle, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, 90, 0), prt.transform).GetComponent<Block>();
                }
                else if (col == new Color(0, 65.0f / 255.0f, 128.0f / 255.0f))
                {
                    blocks[i, j] = Instantiate(intAngle, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, -90, 0), prt.transform).GetComponent<Block>();
                }
                // obstacle slot
                else if (col == new Color(1, 1, 0))
                {
                    blocks[i, j] = Instantiate(obstaclePrefab, new Vector3(i, 0, j) + offset, Quaternion.identity, prt.transform).GetComponent<Block>();
                }
                // Wall
                else if (col == Color.black)
                {
                    GameObject building = buildingsPrefab[Random.Range(0, buildingsPrefab.Length)];
                    blocks[i, j] = Instantiate(building, new Vector3(i, 0, j) + offset, Quaternion.Euler(0, 90 * Random.Range(0, 4), 0), prt.transform).GetComponent<Block>();
                }
                else
                {
                    blocks[i, j] = Instantiate(wallPrefab, new Vector3(i, 0, j) + offset, Quaternion.identity, prt.transform).GetComponent<Block>();
                }
            }
        }
    }
}

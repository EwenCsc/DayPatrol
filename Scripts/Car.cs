using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Car : MonoBehaviour
{
    //enum Direction
    //{
    //    Up, Down, Right, Left
    //}

    public enum VehiculeType
    { 
        None, Police, Thief
    }

    List<Block> tiles = new List<Block>();
    public VehiculeType type = VehiculeType.None;
    NavMeshAgent agent;

    public void Init()
    {
        agent = GetComponent<NavMeshAgent>();
        tiles = FindObjectsOfType<Block>().ToList();

        if (type == VehiculeType.Police)
        {
            Debug.Log(tiles.Find(t => t.isPoliceBegin).transform.position);
            transform.position = tiles.Find(t => t.isPoliceBegin).transform.position;
        }
        else if (type == VehiculeType.Thief)
        {
            Debug.Log(tiles.Find(t => t.isThiefBegin).transform.position);
            transform.position = tiles.Find(t => t.isThiefBegin).transform.position;
        }

        transform.position += Vector3.up * 0.6f;
        agent.SetDestination(tiles.Find(t => t.isEnd).transform.position);
    }
}

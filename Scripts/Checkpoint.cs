using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int id = 0;

    private void Awake()
    {
        int.TryParse(name.Replace("Sphere (", "").Replace(")", ""), out id);
    }
}

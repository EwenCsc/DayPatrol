using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Initilisation : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale *= 3;
        if (GetComponentInChildren<Map>())
        {
            GetComponentInChildren<Map>().Init();
        }

        if (GetComponentsInChildren<Car>().Length > 0)
        {
            GetComponentsInChildren<Car>().ToList().ForEach(c => c.Init());
        }
    }
}

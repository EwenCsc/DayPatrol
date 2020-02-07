using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] GameObject loseEndPrefab;
    [SerializeField] GameObject winEndPrefab;
    
    [SerializeField] 

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void LoseGame()
    {
        // instantiate loseEndObject
        Instantiate(loseEndPrefab);
    }

    public void WinGame()
    {
        // instantiate loseEndObject
        Instantiate(winEndPrefab);
    }
}

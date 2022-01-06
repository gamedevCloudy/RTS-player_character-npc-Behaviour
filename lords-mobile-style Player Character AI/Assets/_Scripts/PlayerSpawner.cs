using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab; 
    [SerializeField]
    private Transform spawnPos;
    
    public Transform enemyContainer; 
    private float timer = 5f; 

    public int playerTroopCounter = -1; 

    void Update()
    {
        timer -= Time.deltaTime; 
        if(timer < 0)
        {
            Instantiate(playerPrefab , spawnPos.position, Quaternion.identity); 
            playerTroopCounter += 1; 
            timer = 5f; 
        }
    }
}

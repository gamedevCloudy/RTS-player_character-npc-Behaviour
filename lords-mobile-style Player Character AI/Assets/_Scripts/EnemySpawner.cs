using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; 
    [SerializeField] 
    private Transform spawnPos; 
    
    public Transform playerContainer; 
    private float timer = 5f; 

    public int enemyTroopCount = -1; 

    void Update()
    {
        timer -= Time.deltaTime; 
        if(timer < 0)
        {
            Instantiate(enemyPrefab , spawnPos.position, Quaternion.identity); 
            enemyTroopCount += 1; 
            timer = 5f; 
        }
        //banana? 
    }
}

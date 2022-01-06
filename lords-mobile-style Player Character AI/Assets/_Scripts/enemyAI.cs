using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class enemyAI : MonoBehaviour
{
    
    private NavMeshAgent nav; 

    private Transform target; 
    private EnemySpawner enemySpawner; 

    private enum State
    {
        Idle, Chase
    }
    private State currentState; 

    void Start()
    {
        currentState = State.Idle; 
        transform.parent = GameObject.Find("Enemy Container").transform; 
        enemySpawner = transform.parent.gameObject.GetComponent<EnemySpawner>(); 
        target = GameObject.Find("Player Container").transform.GetChild(enemySpawner.enemyTroopCount);
        nav = GetComponent<NavMeshAgent>(); 


    }

    void Update()
    {
        switch (currentState)
        {
            default:
            case State.Idle: 
                FindTarget();
                break; 
            case State.Chase:
                transform.LookAt(target); 
                nav.SetDestination(target.position); 
                break; 
        }
    }

    void FindTarget()
    {
        float targetRange = 10f;
        target = GameObject.Find("Player Container").transform.GetChild(enemySpawner.enemyTroopCount);
        if (Vector3.Distance(transform.position, target.position) < targetRange)
        {
            currentState = State.Chase;
        }
    }
}

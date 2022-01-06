using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class PlayerAI : MonoBehaviour
{
    
    private NavMeshAgent nav; 

    private Transform target; 
    private PlayerSpawner playerSpawner; 

    private enum State
    {
        Idle, Chase
    }
    private State currentState; 
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Idle; 
        transform.parent = GameObject.Find("Player Container").transform; 
        playerSpawner = transform.parent.GetComponent<PlayerSpawner>(); 
        //target = GameObject.Find("Enemy Container").transform.GetChild(playerSpawner.playerTroopCounter);
        // target = transform.parent.GetComponent<PlayerSpawner>().enemyContainer; 
        nav = GetComponent<NavMeshAgent>(); 

    }

    // Update is called once per frame
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
                //transform.Translate(target.position); 
                nav.SetDestination(target.position); 
                break; 
        }
    }

    void FindTarget()
    {
        float targetRange = 10f;
        target = GameObject.Find("Enemy Container").transform.GetChild(playerSpawner.playerTroopCounter);
        if (Vector3.Distance(transform.position, target.position) < targetRange)
        {
            //attack target
            currentState = State.Chase;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAIMove : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public LayerMask groundLayer, playerLayer;
    //Moving
    Vector3 destPoint;
    bool walkPointSet;
    public float walkRange;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //Gets NAV Mesh at start of game to determine where it can move
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    //Checks for a set walk point. If one isn't set the SearchForDest function is called 
    {
        if (!walkPointSet)
        {
            SearchForDest();
        }
        if (walkPointSet) 
        {
            agent.SetDestination(destPoint);
        }
        if (Vector3.Distance(transform.position, destPoint) < 15) //was 10
        {
            walkPointSet = false;
        }

    }

    void SearchForDest() //Finds a random point within the assigned NAVmesh and moves to it
    {
        float z = UnityEngine.Random.Range(-walkRange, walkRange);
        float x = UnityEngine.Random.Range(-walkRange, walkRange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destPoint, Vector3.down, groundLayer)) //Shoots a raycast into the ground to check if it has reached the walk point
        {
            walkPointSet = true;
        }
    }
}

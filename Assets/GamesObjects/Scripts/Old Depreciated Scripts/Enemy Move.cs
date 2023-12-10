using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(new Vector3(Random.Range(-7, 7),Random.Range(0.5f, 3),Random.Range(5, 20)));
    }
}

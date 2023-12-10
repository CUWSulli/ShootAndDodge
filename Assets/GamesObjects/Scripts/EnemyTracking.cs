using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTracking : MonoBehaviour
{
    public Transform playerPosition;
    public Player player;
    public NavMeshAgent enemy;
    public float bulletVelocity;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    [SerializeField] private float timer = 5;
    private float enemyFireRate;
    void Start()
    {
        //Searches for the players hitbox to give it something to aim at
        GameObject playerObject = GameObject.FindWithTag("PlayerHitBox");
        //StartCoroutine (ShootDelay());
        if (playerObject != null)
        {
            playerObject.GetComponent<Player>();
        }
        else
        {
            Debug.LogError("Player GameObject not Found");
        }

    }

    
    void Update()
    {
        enemy.transform.LookAt(playerPosition.position); //Aims enemy towards the main camera
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        if (player.playerHealth >= 0)
        {

        enemyFireRate -= Time.deltaTime; //Spawns a bullet every x seconds based on the enemyFireRate variable

        if (enemyFireRate > 0)
        {
            return;
        } 
        enemyFireRate = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject; //Spawns the bullet and multiplys its force by the bulletVelocity
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * bulletVelocity);
        Destroy(bulletObj, 10); //Despawns enemy projectile after 10 seconds to improve performance
        if (player.playerHealth <= 0)
        {
            //Debug.Log("PlayerhasDied");
            return;
        }
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(3);
    }
    void StopShooting()
    {
        
    }
}

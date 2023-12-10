using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float defaultPlayerHealth;
    public Transform respawnPoint;
    public GameObject deathScreen;
    public GameObject restartButton;
    public GameObject rightRay;
    public GameObject leftRay;
    public GameObject shield;
    public GameObject gun1;
    public GameObject gun2;
    public Text healthCounter;
    public AudioSource src;
    public AudioClip deathSound, damageSound, restartSound;
    public int playerHealth = 10;
    


    void Start()
    {
        src.clip = restartSound;
        src.Play();
        //Hides things the user shouldn't see at the start of the game such as UI interactors and the deathscreen
        restartButton.SetActive(false);
        rightRay.SetActive(false);
        leftRay.SetActive(false);
        deathScreen.SetActive(false);
        
        healthCounter.text = playerHealth.ToString();
        //playerHealth = defaultPlayerHealth;
    }

    
    void Update()
    {
        //Makes sure the enemies stop shooting once the player has died. This prevents the health from going into the negatives
        if (playerHealth <= 0)
            {
                foreach (var enemyProj in GameObject.FindGameObjectsWithTag("EnemyBullet"))
                {
                    Destroy(enemyProj);
                }
            }
    }

    //Basic Function for Calculating Health
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            playerHealth = playerHealth - 1;
            src.clip = damageSound;
            src.Play();
            healthCounter.text = playerHealth.ToString(); //Update the health counter every time health is lost
            //Debug.Log(playerHealth);
            if (playerHealth <= 0)
            {
                src.clip = deathSound;
                src.Play();
                foreach (var enemyProj in GameObject.FindGameObjectsWithTag("EnemyBullet"))
                {
                    Destroy(enemyProj);
                }
                //When the player has died activate UI elements and Restart Screen
                restartButton.SetActive(true);
                deathScreen.SetActive(true);
                rightRay.SetActive(true);
                leftRay.SetActive(true);
                gun1.SetActive(false);
                gun2.SetActive(false);
                shield.SetActive(false);
            }
        }
    }
    /*
    Old non-working code I used initially for despawning enemies
    private void DestroyAll(string tag)
    {
        GameObject enemies = GameObject.FindGameObjectWithTag("EnemyBullet");
                for(int i=0; i< enemies.length; i++)
                {
                    Destroy(enemies);
                }
    }
    */
}

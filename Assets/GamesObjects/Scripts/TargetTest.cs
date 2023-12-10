using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class TargetTest : MonoBehaviour
{   
    public float glideSpeed = 2f;
    public float defaultHealth;
    public float targetHealth;
    public bool isFarTarget;
    public int points;
    public int respawnTime;
    public AudioSource src;
    public AudioClip targetHit, targetDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        targetHealth = defaultHealth;
        TargetScore scoreScript = GetComponent<TargetScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Bullet"))
        {   
            src.clip = targetHit;
            src.Play();
            Destroy(other.gameObject); //If the target is hit by a Bullet fired from the players gun, reduce the health by 10.
            targetHealth = targetHealth - 10;
            if (targetHealth <= 0 && isFarTarget == false) //isFarTarget determines how far targets can move. Targets without this checked will stay close to the player.
            {
                GameObject scoreManagerObject = GameObject.FindWithTag("ScoreManager"); //Get the ScoreManager Gameobject that contains the TargetScore script
                
                if (scoreManagerObject != null)
                {
                    TargetScore targetScoreScript = scoreManagerObject.GetComponent<TargetScore>(); //Get the TargetScore script attatched to the game object
                    if (targetScoreScript != null)
                    {
                        targetScoreScript.increaseScore(points);
                    }
                    else
                    {
                        Debug.LogError("TargetScore Script not Found");
                    }
                }
                else
                {

                    Debug.Log("Missing Score Manager Object");
                }
                src.clip = targetDestroyed;
                src.Play();
                gameObject.transform.position = new Vector3(Random.Range(-5.5f, 5),Random.Range(0.5f, 5),Random.Range(8, 3)); //Move to new random position in this range
                targetHealth = defaultHealth; //Reset the health
            }
            if (targetHealth <= 0 && isFarTarget == true) //isFarTargets that have this setting checked can move much further and at a greater range than non far targets.
            {
                GameObject scoreManagerObject = GameObject.FindWithTag("ScoreManager");

                if (scoreManagerObject != null)
                {
                    TargetScore targetScoreScript = scoreManagerObject.GetComponent<TargetScore>();
                    if (targetScoreScript != null)
                    {
                        targetScoreScript.increaseScore(points);
                    }
                    else
                    {
                        Debug.LogError("TargetScore Script not Found");
                    }
                }
                else
                {

                    Debug.Log("Missing Score Manager Object");
                }
                src.clip = targetDestroyed;
                src.Play();
                Vector3 randomDestination = new Vector3(Random.Range(-7, 7), Random.Range(0.5f, 3f), Random.Range(5, 20));
                transform.position = Vector3.Lerp(transform.position, randomDestination, Time.deltaTime * glideSpeed);
                targetHealth = defaultHealth;

            }
            //print("HIT");
        }
    }


    /*
    Old Scripts I was messing with but didn't end up working in the long run
    
    private void SpawnDelay()
    {
        //gameObject.SetActive(false);
    }
 
    //Invoke("SpawnDelay", respawnTime);
    //gameObject.SetActive(true);
    //currentScore = currentScore + points;
    //scoreUI.text = currentScore.ToString();
    //Debug.Log(currentScore);
    //TargetScore scoreScript = GetComponent<TargetScore>();
 
 
 
    */
}


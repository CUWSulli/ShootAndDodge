using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDelay : MonoBehaviour
{   
    public GameObject enemy;
    //Spawns in the enemies after the countdown at the start finishes
    void Start()
    {
        Invoke("FireDelay", 11);
        //StartCoroutine (FireDelay());
    }
    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(3);
        enemy.SetActive(true);
    }
    */

    private void FireDelay()
    {
        enemy.SetActive(true);
        Debug.Log("Spawned");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10;
    /*
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(other.gameObject);
            print("HIT");
        }
    }
    */

}


//If gameobject has tag Target
    //Reduce Health by bulletDamage
    //If targetHealth < 0
        //Destroy GameObject
        //Randomly move to new position

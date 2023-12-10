using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    //public TextMesh score;
    public bool isTargetPractice;
    //public int points;
    public float health = 10f;
    public float defaultHealth;
    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Start()
    {
        defaultHealth = health;
    }
    void Die()
    {
        if (isTargetPractice == true)
        {
            health = defaultHealth;
            gameObject.transform.position = new Vector3(Random.Range(3, -3),Random.Range(0.5f, 3),Random.Range(-2, 2));
            //FindObjectOfType<Score>().IncreaseScore();
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log("Target Broken");
    }


}

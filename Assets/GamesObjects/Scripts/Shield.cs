using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public int defaultShieldHealth;
    public int shieldHealth;
    public Text sHealth;
    public AudioSource src;
    public AudioClip shieldHit, shieldBroken;
    void Start()
    {
        shieldHealth = defaultShieldHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            shieldHealth = shieldHealth -1;
            src.clip = shieldHit;
            src.Play();
            //sHealth.text = shieldHealth.ToString();

            if (shieldHealth <= 0)
            {
                src.clip = shieldBroken;
                src.Play();
                Destroy(gameObject);
            }
        }
    }
}

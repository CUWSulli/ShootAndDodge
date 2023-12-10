using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class FireBulletOnValidate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float bulletVelocity = 20;
    public float defaultAmmo = 10;
    public float remainingAmmo;
    public AudioSource src;
    public AudioClip gunshot, outOfAmmo, reload;
    void Start()
    {
        //Reset the guns ammo at the start to the default 
        remainingAmmo = defaultAmmo;
        
        //Await a trigger pull, if trigger is pulled que FireBullet method
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
        //Code for attempted recoil script that I couldn't get working
        //grabbable.activated.AddListener(StartRecoil);
    }

    void Update()
    {
        
    }
    public void FireBullet(ActivateEventArgs arg)
    {
        if (remainingAmmo > 0) //If ammo remains
        {
        
        src.clip = gunshot;
        src.Play();
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position; //Spawn bullet and move it to the attatch point specified in the gun gameobject
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletVelocity; //Calculate speed and velocity
        Destroy(spawnedBullet, 15); //Destroys bullets after 15 seconds to help performace
        remainingAmmo = remainingAmmo - 1;
        //StartRecoil();
        //Debug.Log(remainingAmmo);
        }
        else if (remainingAmmo == 0)
        {
            src.clip = outOfAmmo;
            src.Play();
            Debug.Log("Out of Ammo");
        }
    }
    /*
    protected virtual void ApplyRecoil()
    {
        
    }
    */
    //Checks if the gun has made contact with an ammo box, if it has reload the firearm by setting the remaining ammo to the defualt
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("AmmoBox"))
        {
            src.clip = reload;
            src.Play();
            remainingAmmo = defaultAmmo;
        }
    }

    /*
    IEnumerator StartRecoil()
    {
        gameObject.GetComponent<Animator>().Play("RecoilAnimation");
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<Animator>().Play("New State");
    }
    */

}

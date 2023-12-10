using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecoilScript : MonoBehaviour
{
    public GameObject gun;
    public Animation recoil;
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        //grabbable.activated.AddListener(StartRecoil);
    }

    void Update()
    {

    }

    IEnumerator StartRecoil()
    {
        gun.GetComponent<Animator>().Play("RecoilAnimation");
        yield return new WaitForSeconds(0.2f);
        gun.GetComponent<Animator>().Play("New");
    }
}

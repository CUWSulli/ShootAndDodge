using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticInteraction : MonoBehaviour
{
    [Range(0,1)] //Inensity can not be greater than 1
    public float intensity;
    public float duration;

    void Start()
    {
        //Adds listener for trigger pull on the object this script is applied too
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(TriggerHaptic);
    }

    public void TriggerHaptic(XRBaseController controller)
    {
        if (intensity > 0 && gameObject.GetComponent<FireBulletOnValidate>().remainingAmmo > 0) 
        //Gets Remaining ammo count from FireBulletOnValidate class to check if magazine is empty
        //Controller should not vibrate if no ammo remains
        {
            controller.SendHapticImpulse(intensity, duration); //Sends a pulse 
        }
    }

    //Similar to other script but directly interacts with XR's action based events
    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if(eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }
}

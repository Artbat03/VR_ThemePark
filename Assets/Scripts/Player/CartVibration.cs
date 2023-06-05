using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CartVibration : MonoBehaviour
{
    // Adding the SerializeField attribute to a field will make it appear in the Inspector window
    // where a developer can drag a reference to the controller that you want to send haptics to.
    [SerializeField] XRBaseController controller_l;
    [SerializeField] XRBaseController controller_r;
    private bool sendVibration;
    protected void Start()
    {
        sendVibration = true;
        StartCoroutine(StartPeriodicHaptics());
        
    }
 
    IEnumerator StartPeriodicHaptics()
    {
        // Trigger haptics every second
        var delay = new WaitForSeconds(0.4f);
 
        while (sendVibration)
        {
            yield return delay;
            SendHaptics();
        }
    }
 
    void SendHaptics()
    {
        if (controller_l != null)
            controller_l.SendHapticImpulse(0.9f, 0.3f);
        if (controller_r != null)
            controller_r.SendHapticImpulse(0.7f, 0.1f);
    }
    public void StopSendHaptics()
    {
        sendVibration = false;
    }
}

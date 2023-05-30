using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VibrateController : MonoBehaviour
{
    // Adding the SerializeField attribute to a field will make it appear in the Inspector window
    // where a developer can drag a reference to the controller that you want to send haptics to.
    [SerializeField] XRBaseController controller_l;
    [SerializeField] XRBaseController controller_r;
    [SerializeField] private float _amplitude = 0.7f;
    [SerializeField] private float _duration = 0.1f;
    [SerializeField] private bool isRightHandHolding;
    [SerializeField] private bool  isLeftHandHolding;

    public static VibrateController instance;
    private void Awake()
    {
        instance = this;
    }
    public void sendVibration(float amplitude, float duration)
    {
        _duration = duration;
        _amplitude = amplitude;
        
        if (controller_l &&  isLeftHandHolding)
            controller_l.SendHapticImpulse(_amplitude, _duration);
        if (controller_r && isRightHandHolding)
            controller_r.SendHapticImpulse(_amplitude, _duration);
    }

    public void SetLeftHandTrue()
    {
        isLeftHandHolding = true;
    }
    public void SetLeftHandFalse()
    {
        isLeftHandHolding = false;
    }
    public void SetRightHandTrue()
    {
        isRightHandHolding = true;
    }
    public void SetRightHandFalse()
    {
        isRightHandHolding = false;
    }
    
}    

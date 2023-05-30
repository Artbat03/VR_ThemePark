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

    public static VibrateController instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (controller_l == null)
            Debug.LogWarning(
                "Reference to the Controller is not set in the Inspector window, this behavior will not be able to send haptics. Drag a reference to the controller that you want to send haptics to.",
                this);

        if (controller_r == null)
            Debug.LogWarning(
                "Reference to the Controller is not set in the Inspector window, this behavior will not be able to send haptics. Drag a reference to the controller that you want to send haptics to.",
                this);
    }

    public void sendVibration(float amplitude, float duration)
    {
        _duration = duration;
        _amplitude = amplitude;
        if (controller_l)
            controller_l.SendHapticImpulse(_amplitude, _duration);
        if (controller_r)
            controller_r.SendHapticImpulse(_amplitude, _duration);
    }
}    

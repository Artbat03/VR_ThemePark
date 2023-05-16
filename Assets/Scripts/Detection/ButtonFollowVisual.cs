using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    // Variables
    // Time that the button is set active after release
    public float deadTime = 1.0f;
    
    // Bool used to lock down button during its set dead time
    private bool _deadTimeActive = false;
    
    // Public Unity Events we can use in the editor and tie other functions for
    public UnityEvent onPressed, onReleased;

    /// <summary>
    /// Check if the current collider entering is the Button and sets off OnPressed event
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") && !_deadTimeActive)
        {
            onPressed?.Invoke();
            Debug.Log("I have been pressed");
        }
    }
    
    /// <summary>
    /// Check if the current collider exiting is the Button and sets off OnReleased event
    /// It will also call a Coroutine to make the button inactive for however long deadTime is set to
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button") && !_deadTimeActive)
        {
            onReleased?.Invoke();
            Debug.Log("I have been released");
            StartCoroutine(WaitForDeadTime());
        }
    }

    /// <summary>
    /// Locks button activity until deadTime has passed and reactivates button activity;
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive = true;

        yield return new WaitForSeconds(deadTime);

        _deadTimeActive = false;
    }

    /*private XRBaseInteractable _interactable;

    private void Awake()
    {
        _interactable = GetComponent<XRBaseInteractable>();
        _interactable.hoverEntered.AddListener(Follow);
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is )
        {
            
        }
    }*/
}

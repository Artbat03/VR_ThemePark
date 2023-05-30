using System;
using UnityEngine;
using UnityEngine.Events;

public class LeverDetection : MonoBehaviour
{
    // Variables
    public UnityEvent leverOn;
    [SerializeField] private Transform leverTransform;
    [SerializeField] private Vector3 leverPos;
    [SerializeField] private Quaternion leverRot;

    private void Awake()
    {
        leverTransform = gameObject.transform;
        leverPos = leverTransform.position;
        leverRot = leverTransform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeverOn"))
        {
            leverOn.Invoke();
        }
        else if (other.CompareTag("LeverOff"))
        {
            
        }
    }

    public void ResetLeverTransform()
    {
        gameObject.transform.position = leverPos;
        gameObject.transform.rotation = leverRot;
    }
}

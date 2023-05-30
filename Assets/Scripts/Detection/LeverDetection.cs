using System;
using UnityEngine;
using UnityEngine.Events;

public class LeverDetection : MonoBehaviour
{
    // Variables
    public UnityEvent leverOn;
    [SerializeField] private CartDetection _cartDetection;

    private void OnValidate()
    {
        if (_cartDetection == null)
        {
            _cartDetection = GameObject.FindGameObjectWithTag("Cart").GetComponent<CartDetection>();
        }
    }

    private void Awake()
    {
        _cartDetection.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeverOn"))
        {
            leverOn.Invoke();
            _cartDetection.enabled = true;
        }
        else if (other.CompareTag("LeverOff"))
        {
            
        }
    }
}

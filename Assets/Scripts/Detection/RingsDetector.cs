using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsDetector : MonoBehaviour
{
    // Variables
    [SerializeField] private ObjectDetection _objectDetection;

    private void OnValidate()
    {
        _objectDetection = gameObject.GetComponentInParent<ObjectDetection>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Table"))
        {
            _objectDetection.objectDroppedBool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _objectDetection.objectDroppedBool = false;
    }
}

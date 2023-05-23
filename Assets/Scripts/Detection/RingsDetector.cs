using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsDetector : MonoBehaviour
{
    // Variables
    private enum RingDetectorType
    {
        FRONT,
        BACK
    }
    
    [SerializeField] private ObjectDetection _objectDetection;
    [SerializeField] private RingDetectorType _ringDetectorType;

    private void OnValidate()
    {
        _objectDetection = gameObject.GetComponentInParent<ObjectDetection>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PinkRing") && _ringDetectorType == RingDetectorType.FRONT)
        {
            _objectDetection.frontBool = true;
        }
        else if (other.CompareTag("YellowRing") && _ringDetectorType == RingDetectorType.FRONT)
        {
            _objectDetection.frontBool = true;
        }
        else if (other.CompareTag("BlueRing") && _ringDetectorType == RingDetectorType.FRONT)
        {
            _objectDetection.frontBool = true;
        }
        
        if (other.CompareTag("PinkRing") && _ringDetectorType == RingDetectorType.BACK)
        {
            _objectDetection.backBool = true;
        }
        else if (other.CompareTag("YellowRing") && _ringDetectorType == RingDetectorType.BACK)
        {
            _objectDetection.backBool = true;
        }
        else if (other.CompareTag("BlueRing") && _ringDetectorType == RingDetectorType.BACK)
        {
            _objectDetection.backBool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _objectDetection.frontBool = false;
        _objectDetection.backBool = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    // Variables
    [SerializeField] private bool objectDetected;
    [SerializeField] private int points;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ring"))
        {
            objectDetected = true;
            ScoreManager.instance.Score += points;
            other.GetComponent<DestroyObject>().DestroyObj();
            objectDetected = false;
            Debug.Log("Ring Points");
        }
        else if (other.CompareTag("Dart"))
        {
            objectDetected = true;
            ScoreManager.instance.Score += points;
            other.GetComponent<DestroyObject>().DestroyObj();
            objectDetected = false;
            Debug.Log("Dart points");
            
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        objectDetected = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    // Variables
    [SerializeField] private int points;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ring"))
        {
            ScoreManager.instance.Score += points;
            BottlesManager.instance.RingsInScene--;
            other.GetComponent<DestroyObject>().DestroyObj();
            Debug.Log("Ring Points");
        }
        else if (other.CompareTag("Dart"))
        {
            ScoreManager.instance.Score += points;
            BalloonManager.instance.DartsInScene--;
            other.GetComponent<DestroyObject>().DestroyObj();
            Debug.Log("Dart points");
            
            Destroy(this.gameObject);
        }
    }
}

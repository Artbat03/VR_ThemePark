using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectDetection : MonoBehaviour
{
    // Variables
    [SerializeField] private int points;
    public bool objectDroppedBool;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Table"))
        {
            if (objectDroppedBool)
            {
                ScoreManager.instance.RingsScore += points;
                PlayerPrefs.SetInt("RingsScore", ScoreManager.instance.RingsScore);
                
                if (other.CompareTag("Ring"))
                {
                    other.GetComponent<DestroyObject>().DestroyObj();
                }
                Debug.Log("Ring Points");
            }
        }
        else if (other.CompareTag("Dart"))
        {
            ScoreManager.instance.DartsScore += points;
            PlayerPrefs.SetInt("DartsScore", ScoreManager.instance.DartsScore);
            other.GetComponent<DestroyObject>().DestroyObj();
            Debug.Log("Dart points");
            
            Destroy(this.gameObject);
        }
    }
}

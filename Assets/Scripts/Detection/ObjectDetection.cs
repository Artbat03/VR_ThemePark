using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    // Variables
    [SerializeField] private int points;
    public bool frontBool;
    public bool backBool;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PinkRing"))
        {
            if (frontBool && backBool)
            {
                ScoreManager.instance.RingsScore += points;
                PlayerPrefs.SetInt("RingsScore", ScoreManager.instance.RingsScore);
                BottlesManager.instance.PinkRingsInScene--;
                other.GetComponent<DestroyObject>().DestroyObj();
                Debug.Log("Pink Ring Points");
            }
        }
        else if (other.CompareTag("YellowRing"))
        {
            if (frontBool && backBool)
            {
                ScoreManager.instance.RingsScore += points;
                PlayerPrefs.SetInt("RingsScore", ScoreManager.instance.RingsScore);
                BottlesManager.instance.YellowRingsInScene--;
                other.GetComponent<DestroyObject>().DestroyObj();
                Debug.Log("Yellow Ring Points");
            }
        }
        else if (other.CompareTag("BlueRing"))
        {
            if (frontBool && backBool)
            {
                ScoreManager.instance.RingsScore += points;
                PlayerPrefs.SetInt("RingsScore", ScoreManager.instance.RingsScore);
                BottlesManager.instance.BlueRingsInScene--;
                other.GetComponent<DestroyObject>().DestroyObj();
                Debug.Log("Blue Ring Points");
            }
        }
        else if (other.CompareTag("Dart"))
        {
            ScoreManager.instance.DartsScore += points;
            PlayerPrefs.SetInt("DartsScore", ScoreManager.instance.DartsScore);
            BalloonManager.instance.DartsInScene--;
            other.GetComponent<DestroyObject>().DestroyObj();
            Debug.Log("Dart points");
            
            Destroy(this.gameObject);
        }
    }
}

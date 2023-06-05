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
    public bool isGlass;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Table"))
        {
            if (objectDroppedBool)
            {
                if (isGlass)
                {
                    AudioManager.instance.PlaySFX(AudioManager.instance.listaAudio[8]);
                }
                else
                {
                    AudioManager.instance.PlaySFX(AudioManager.instance.listaAudio[9]);
                }
                
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
            AudioManager.instance.PlaySFX(AudioManager.instance.listaAudio[6]);
            ScoreManager.instance.DartsScore += points;
            PlayerPrefs.SetInt("DartsScore", ScoreManager.instance.DartsScore);
            other.GetComponent<DestroyObject>().DestroyObj();
            Debug.Log("Dart points");
            
            Destroy(this.gameObject);
        }
    }
}

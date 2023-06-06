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
    [SerializeField] private bool isGlass;
    [SerializeField] private ParticleSystem particleSystem;

    private void Awake()
    {
        if (this.gameObject.CompareTag("Balloon"))
        {
            particleSystem.Stop();
        }
    }

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
            
            particleSystem.Play();

            StartCoroutine(Coroutine_Destroy());
        }
    }

    IEnumerator Coroutine_Destroy()
    {
        yield return new WaitForSeconds(.15f);
        Destroy(this.gameObject);
    }
}

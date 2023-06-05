using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public void DestroyObj()
    {
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Table"))
        {
            if (this.gameObject.CompareTag("Ring"))
            {
                BottlesManager.instance.RingsInScene--;
            }
            
            if (this.gameObject.CompareTag("Dart"))
            {
                BalloonManager.instance.DartsInScene--;
            }
            
            DestroyObj();
        }
    }
}

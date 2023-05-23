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
        if (other.gameObject.CompareTag("Floor"))
        {
            if (this.gameObject.CompareTag("PinkRing"))
            {
                BottlesManager.instance.PinkRingsInScene--;
            }
            else if (this.gameObject.CompareTag("YellowRing"))
            {
                BottlesManager.instance.YellowRingsInScene--;
            }
            else if (this.gameObject.CompareTag("BlueRing"))
            {
                BottlesManager.instance.BlueRingsInScene--;
            }
            else if (this.gameObject.CompareTag("Dart"))
            {
                BalloonManager.instance.DartsInScene--;
            }
            
            DestroyObj();
        }
    }
}

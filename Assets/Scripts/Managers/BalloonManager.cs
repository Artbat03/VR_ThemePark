using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    // Variables
    public static BalloonManager instance;
    
    [SerializeField] private int dartsInScene;
    
    #region GETTERS && SETTERS

    public int DartsInScene
    {
        get => dartsInScene;
        set => dartsInScene = value;
    }

    #endregion

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            CheckDartsInScene();
        }
    }

    public void CheckDartsInScene()
    {
        if (dartsInScene <= 0 && GameManager.instance.NameStand == "DartsStand")
        {
            GameManager.instance.isPlaying = false;
            GameManager.instance.NameStand = null;
            
            AudioManager.instance.PlayMusic(AudioManager.instance.listaAudio[1]);
            
            if (!ScoreManager.instance.DartsToyReached)
            {
                ScoreManager.instance.CheckScoreForReward();
            }
            
            //Destroy(GameObject.FindGameObjectWithTag("BalloonsWall").gameObject);
        }
    }
}

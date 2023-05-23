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
        if (GameManager.instance.isPlaying && dartsInScene >= 3)
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

            if (!ScoreManager.instance.DartsToyReached)
            {
                ScoreManager.instance.CheckScoreForReward();
            }
        }
    }
}

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

        dartsInScene = GameObject.FindGameObjectsWithTag("Dart").Length;
    }

    private void Update()
    {
        CheckDartsInScene();
    }

    public void CheckDartsInScene()
    {
        if (dartsInScene <= 0)
        {
            GameManager.instance.IsPlaying = false;
        }
    }
}

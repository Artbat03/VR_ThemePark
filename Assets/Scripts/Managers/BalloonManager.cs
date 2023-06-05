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
            dartsInScene = GameObject.FindGameObjectsWithTag("Dart").Length;
            Invoke("CheckDartsInScene", 1f);
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
            
            Destroy(GameManager.instance.spawnedDartGameGameObject.gameObject);
            Destroy(GameManager.instance.spawnedDartsGameObject.gameObject);
        }
    }
}

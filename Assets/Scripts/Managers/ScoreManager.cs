
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Variables
    public static ScoreManager instance;
    
    [SerializeField] private int score;

    #region GETTERS && SETTERS

    public int Score
    {
        get => score;
        set => score = value;
    }

    #endregion

    private void Awake()
    {
        instance = this;
    }
}

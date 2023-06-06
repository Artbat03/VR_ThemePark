
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Variables
    public static ScoreManager instance;
    
    [Header("INDIVIDUAL SCORES")]
    [SerializeField] private int ringsScore;
    [SerializeField] private int dartsScore;
    [SerializeField] private int tunnelScore;
    
    [Space(10)]
    [SerializeField] private int maxPointsToReach;

    [SerializeField] private bool ringsToyReached;
    [SerializeField] private bool dartsToyReached;
    [SerializeField] private bool tunnelToyReached;
    
    [Space(15), Header("REWARDS PARENT")]
    [SerializeField] private Transform rewardsParent;
    
    [Space(15), Header("REWARDS PREFABS")]
    [SerializeField] private GameObject ringsToy;
    [SerializeField] private GameObject dartsToy;
    [SerializeField] private GameObject tunnelToy;

    #region GETTERS && SETTERS

    public int RingsScore
    {
        get => ringsScore;
        set => ringsScore = value;
    }
    
    public int DartsScore
    {
        get => dartsScore;
        set => dartsScore = value;
    }
    
    public int TunnelScore
    {
        get => tunnelScore;
        set => tunnelScore = value;
    }

    public bool RingsToyReached
    {
        get => ringsToyReached;
        set => ringsToyReached = value;
    }
    
    public bool DartsToyReached
    {
        get => dartsToyReached;
        set => dartsToyReached = value;
    }
    
    public bool TunnelToyReached
    {
        get => tunnelToyReached;
        set => tunnelToyReached = value;
    }

    #endregion

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ringsScore = PlayerPrefs.GetInt("RingsScore", 0);
        dartsScore = PlayerPrefs.GetInt("DartsScore", 0);
        tunnelScore = PlayerPrefs.GetInt("TunnelScore", 0);
        CheckScoreForReward();
    }

    public void CheckScoreForReward()
    {
        if (rewardsParent != null)
        {
            if (ringsScore >= maxPointsToReach && !ringsToyReached)
            {
                ringsToyReached = true;
                Instantiate(ringsToy, rewardsParent.GetChild(0).position, rewardsParent.GetChild(0).rotation,
                    rewardsParent.GetChild(0));
            }
            else if (dartsScore >= maxPointsToReach && !dartsToyReached)
            {
                dartsToyReached = true;
                Instantiate(dartsToy, rewardsParent.GetChild(1).position, rewardsParent.GetChild(1).rotation,
                    rewardsParent.GetChild(1));
            }
            else if (tunnelScore >= maxPointsToReach && !tunnelToyReached)
            {
                tunnelToyReached = true;
                Instantiate(tunnelToy, rewardsParent.GetChild(2).position, rewardsParent.GetChild(2).rotation,
                    rewardsParent.GetChild(2));
            }
        }
    }
}

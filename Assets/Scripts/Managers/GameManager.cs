using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    // Variables
    public static GameManager instance;
    
    [Header("PLAYER PARAMS")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private ActionBasedContinuousMoveProvider playerMovement;
    
    [Space(15), Header("GAME PLAYER TRANSFORMS")]
    [SerializeField] private Transform gamePlayerTransformParent;
    [SerializeField] private List<Transform> gamePlayerTransforms;
    
    [Space(15), Header("STAND PARAMS")]
    [SerializeField] private bool isPlaying;
    [SerializeField] private string nameStand;
    
    #region GETTERS && SETTERS

    public bool IsPlaying
    {
        get => isPlaying;
        set => isPlaying = value;
    }

    public string NameStand
    {
        get => nameStand;
        set => nameStand = value;
    }

    #endregion

    private void OnValidate()
    {
        if (playerMovement == null)
        {
            playerMovement = FindObjectOfType<ActionBasedContinuousMoveProvider>();
        }

        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    private void Awake()
    {
        instance = this;
        
        if (gamePlayerTransformParent != null)
        {
            for (int i = 0; i < gamePlayerTransformParent.childCount; i++)
            {
                gamePlayerTransforms.Add(gamePlayerTransformParent.GetChild(i));
            }
        }
    }

    private void Update()
    {
        CheckPlay();
    }

    public void NameStandTransform(string standName)
    {
        if (standName == "RingsStand")
        {
            playerTransform.position = gamePlayerTransforms[0].position;
        }
        else if (standName == "DartsStand")
        {
            playerTransform.position = gamePlayerTransforms[1].position;
        }
        else if (standName == "TunnelStand")
        {
            playerTransform.SetParent(gamePlayerTransforms[2].transform);
            playerTransform.position = gamePlayerTransforms[2].position;
        }
    }
    
    public void CheckPlay()
    {
        if (isPlaying)
        {
            playerMovement.enabled = false;
            UIManager.instance.HidePlayPanels();
        }
        else
        {
            playerMovement.enabled = true;
            UIManager.instance.ShowPlayPanels();
        }
    }
}

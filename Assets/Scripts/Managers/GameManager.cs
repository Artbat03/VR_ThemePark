using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    // Variables
    public static GameManager instance;

    [Header("PLAYER PARAMS")]
    [SerializeField] private GameObject player;
    [SerializeField] private Transform vagonetaTransform;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ActionBasedContinuousMoveProvider playerMovement;
    
    [Space(15), Header("GAME PLAYER TRANSFORMS")]
    public List<Transform> gamePlayerTransforms;
    
    [Space(15), Header("STAND PARAMS")]
    public bool isPlaying;
    [SerializeField] private string nameStand;

    [Space(15), Header("SPAWN OBJECTS")]
    [SerializeField] private Transform pistolTransform;
    [SerializeField] private GameObject pinkRings;
    [SerializeField] private GameObject yellowRings;
    [SerializeField] private GameObject blueRings;
    [SerializeField] private GameObject darts;
    [SerializeField] private GameObject pistol;
    
    #region GETTERS && SETTERS

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

        if (_playerController == null)
        {
            _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        CheckPlay();
    }

    public void NameStandTransform(string standName)
    {
        NameStand = standName;
        
        if (standName == "RingsStandLevel1")
        {
            _playerController.ResetPosition(gamePlayerTransforms[0]);
            Instantiate(pinkRings);
            BottlesManager.instance.PinkRingsInScene = GameObject.FindGameObjectsWithTag("PinkRing").Length;
        }
        else if (standName == "RingsStandLevel2")
        {
            _playerController.ResetPosition(gamePlayerTransforms[1]);
            Instantiate(yellowRings);
            BottlesManager.instance.YellowRingsInScene = GameObject.FindGameObjectsWithTag("YellowRing").Length;
        }
        else if (standName == "RingsStandLevel3")
        {
            _playerController.ResetPosition(gamePlayerTransforms[2]);
            Instantiate(blueRings);
            BottlesManager.instance.BlueRingsInScene = GameObject.FindGameObjectsWithTag("BlueRing").Length;
        }
        else if (standName == "DartsStand")
        {
            _playerController.ResetPosition(gamePlayerTransforms[3]);
            Instantiate(darts);
            BalloonManager.instance.DartsInScene = GameObject.FindGameObjectsWithTag("Dart").Length;
        }
        else if (standName == "TunnelStand")
        {
            //_playerController.ResetPosition(gamePlayerTransforms[4]);
            player.transform.SetParent(vagonetaTransform);
            GameObject gun = Instantiate(pistol, pistolTransform.position, pistolTransform.rotation);
            gun.transform.SetParent(vagonetaTransform);
        }

        isPlaying = true;
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

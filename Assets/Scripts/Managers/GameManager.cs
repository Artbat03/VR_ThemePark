using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
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
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform balloonsTransform;
    [SerializeField] private Transform pistolTransform;
    [SerializeField] private GameObject gamePrefab;
    [SerializeField] private GameObject rings;
    [SerializeField] private GameObject balloonsWall;
    [SerializeField] private GameObject darts;
    [SerializeField] private GameObject pistol;

    public GameObject spawnedRingsGameObject;
    public GameObject spawnedDartsGameObject;
    public GameObject spawnedRingGameGameObject;
    public GameObject spawnedDartGameGameObject;
    public GameObject spawnedGunGameObject;
    
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
        
        if (standName == "RingsStand")
        {
            _playerController.ResetPosition(gamePlayerTransforms[0]);
            spawnedRingsGameObject = Instantiate(rings);
            BottlesManager.instance.RingsInScene = GameObject.FindGameObjectsWithTag("Ring").Length;
            spawnedRingGameGameObject = Instantiate(gamePrefab, gameTransform.position, gameTransform.rotation);
            spawnedRingGameGameObject.transform.SetParent(gameTransform);
        }
        else if (standName == "DartsStand")
        {
            _playerController.ResetPosition(gamePlayerTransforms[1]);
            spawnedDartsGameObject = Instantiate(darts);
            BalloonManager.instance.DartsInScene = GameObject.FindGameObjectsWithTag("Dart").Length;
            spawnedDartGameGameObject = Instantiate(balloonsWall);
            spawnedDartGameGameObject.transform.SetParent(balloonsTransform);
        }
        else if (standName == "TunnelStand")
        {
            _playerController.ResetPosition(gamePlayerTransforms[2]);
            player.transform.SetParent(vagonetaTransform);
            spawnedGunGameObject = Instantiate(pistol, pistolTransform.position, pistolTransform.rotation);
            spawnedGunGameObject.transform.SetParent(pistolTransform);
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

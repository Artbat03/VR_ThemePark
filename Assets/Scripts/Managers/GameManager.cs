using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    // Variables
    public static GameManager instance;
    
    [Header("PLAYER PARAMS")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ActionBasedContinuousMoveProvider playerMovement;
    
    [Space(15), Header("GAME PLAYER TRANSFORMS")]
    [SerializeField] private Transform gamePlayerTransformParent;
    [SerializeField] private List<Transform> gamePlayerTransforms;
    
    [Space(15), Header("STAND PARAMS")]
    [SerializeField] private bool isPlaying;
    [SerializeField] private string nameStand;

    [Space(15), Header("SPAWN OBJECTS")]
    [SerializeField] private Transform pistolTransform;
    [SerializeField] private GameObject rings;
    [SerializeField] private GameObject darts;
    [SerializeField] private GameObject pistol;
    
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

        if (_playerController == null)
        {
            _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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

    private void Start()
    {
        rings.SetActive(false);
        darts.SetActive(false);
        pistol.SetActive(false);
    }

    private void Update()
    {
        CheckPlay();
    }

    public void NameStandTransform(string standName)
    {
        if (standName == "RingsStand")
        {
            _playerController.ResetPosition(gamePlayerTransforms[0]);
            Instantiate(rings);
        }
        else if (standName == "DartsStand")
        {
            _playerController.ResetPosition(gamePlayerTransforms[1]);
            Instantiate(darts);
        }
        else if (standName == "TunnelStand")
        {
            _playerController.ResetPosition(gamePlayerTransforms[2]);
            Instantiate(pistol, pistolTransform.position, pistolTransform.rotation);
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class CartDetection : MonoBehaviour
{
    // Variables
    [Header("PLAYER PARAMS")]
    [SerializeField] private bool isPlayerIn;
    [SerializeField] private GameObject player;
    
    [Space(15), Header("CART PARAMS")]
    [SerializeField] private Transform worldTransform;
    [SerializeField] private Animator cartAnim;
    
    [Space(15), Header("INPUT ACTIONS")]
    [SerializeField] private InputActionReference backBtn;

    [Space(15), Header("ENEMIES PARAMS")]
    [SerializeField] private int randomInt;
    [SerializeField] private List<GameObject> enemiesToKillList;

    //[Space(15), Header("SCRIPT REFERENCES")]
    //[SerializeField] private LeverDetection _leverDetection;

    private void Awake()
    {
        cartAnim = GetComponent<Animator>();
        randomInt = Random.Range(0, enemiesToKillList.Count);
        //_leverDetection = FindObjectOfType<LeverDetection>();
    }

    private void Update()
    {
        if (isPlayerIn && backBtn.action.IsPressed())
        {
            GameManager.instance.isPlaying = false;
        }

        if (!isPlayerIn)
        {
            foreach (var target in GameObject.FindGameObjectsWithTag("Target"))
            {
                Destroy(target);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = true;
            
            if (isPlayerIn)
            {
                cartAnim.SetTrigger("Accelerate");
            }
        }
        else if (other.CompareTag("EnemyTrigger"))
        {
            RandomEnemy(other.transform);
        }
        else if (other.CompareTag("TunnelOut"))
        {
            isPlayerIn = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = false;
        }
    }
    
    /// <summary>
    /// Method for spawn a random enemy from a list in a specific transform
    /// </summary>
    /// <param name="enemyTriggerTransform"></param>
    public void RandomEnemy(Transform enemyTriggerTransform)
    {
        randomInt = Random.Range(0, enemiesToKillList.Count);
        Instantiate(enemiesToKillList[randomInt], enemyTriggerTransform.GetChild(0).position, enemyTriggerTransform.GetChild(0).rotation);
    }
    
    /// <summary>
    /// Method for when the cart animation finishes
    /// </summary>
    public void PlayerOut()
    {
        isPlayerIn = false;
        
        AudioManager.instance.PlayMusic(AudioManager.instance.listaAudio[1]);
        GameManager.instance.isPlaying = false;
        GameManager.instance.NameStand = null;
        player.transform.SetParent(null);
        player.transform.position = worldTransform.position;
        player.transform.rotation = worldTransform.rotation;
        Destroy(GameManager.instance.spawnedGunGameObject.gameObject);
        //_leverDetection.ResetLeverTransform();
    }
}

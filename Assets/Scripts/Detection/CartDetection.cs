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

    private void Awake()
    {
        cartAnim = GetComponent<Animator>();
        randomInt = Random.Range(0, enemiesToKillList.Count);
    }

    private void Update()
    {
        if (isPlayerIn && backBtn.action.IsPressed())
        {
            GameManager.instance.isPlaying = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = true;
            
            if (GameManager.instance.isPlaying)
            {
                cartAnim.SetTrigger("Accelerate");
            }
        }
        else if (other.CompareTag("EnemyTrigger"))
        {
            RandomEnemy(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = false;
        }
    }

    public void RandomEnemy(Transform enemyTriggerTransform)
    {
        randomInt = Random.Range(0, enemiesToKillList.Count);
        Instantiate(enemiesToKillList[randomInt], enemyTriggerTransform.GetChild(0).position, enemyTriggerTransform.GetChild(0).rotation);
    }

    public void PlayerOut()
    {
        isPlayerIn = false;
        GameManager.instance.isPlaying = false;
        GameManager.instance.NameStand = null;
        player.transform.SetParent(null);
        player.transform.position = worldTransform.position;
        player.transform.rotation = worldTransform.rotation;
    }
}

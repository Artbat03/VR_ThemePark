using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CartDetection : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Transform worldTransform;

    [SerializeField] private Animator vagonetaAnim;
    [SerializeField] private bool isPlayerIn;
    [SerializeField] private InputActionReference backBtn;

    private void Awake()
    {
        vagonetaAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPlayerIn && backBtn.action.IsPressed())
        {
            GameManager.instance.IsPlaying = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = true;
            
            if (isPlayerIn)
            {
                vagonetaAnim.SetTrigger("Accelerate");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = false;
        }
    }

    public void PlayerOut()
    {
        isPlayerIn = false;
        GameManager.instance.IsPlaying = false;
        player.transform.SetParent(null);
        player.transform.position = worldTransform.position;
        player.transform.rotation = worldTransform.rotation;
    }
}

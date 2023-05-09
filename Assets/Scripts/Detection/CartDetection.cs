using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CartDetection : MonoBehaviour
{
    // Variables
    [SerializeField] private bool isPlayerIn;
    [SerializeField] private InputActionReference backBtn;

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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = false;
        }
    }
}

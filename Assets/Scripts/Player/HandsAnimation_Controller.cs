using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandsAnimation_Controller : MonoBehaviour
{
    // Variables
    [Header("INPUT ACTION CONTROLLERS")]
    [SerializeField] private InputActionReference gripInput;
    [SerializeField] private InputActionReference triggerInput;

    // Private variables
    private Animator _anim;
    private float grip;
    private float trigger;

    private void Awake()
    {
        // Getting components
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        GetInputs();
    }

    public void GetInputs()
    {
        // Reading values
        grip = gripInput.action.ReadValue<float>();
        trigger = triggerInput.action.ReadValue<float>();
        
        // Assigning values to the animator parameters
        _anim.SetFloat("Grip", grip);
        _anim.SetFloat("Trigger", trigger);
    }
}

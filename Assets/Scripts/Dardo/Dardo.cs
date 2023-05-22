using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dardo : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    [SerializeField] private VelocityEstimator _leftVelocityEstimator;
    [SerializeField] private VelocityEstimator _rightVelocityEstimator;
    [SerializeField] private float leftVelocity;
    [SerializeField] private float rightVelocity;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        _leftVelocityEstimator = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<VelocityEstimator>();
        _rightVelocityEstimator = GameObject.FindGameObjectWithTag("RightHand").GetComponent<VelocityEstimator>();
    }

    public void ApplyVelocity()
    {
        leftVelocity = _leftVelocityEstimator.GetVelocityEstimate().magnitude;
        rightVelocity = _rightVelocityEstimator.GetVelocityEstimate().magnitude;

        if (leftVelocity > 0.5f || rightVelocity > 0.5f)
        {
            rb.AddForce((transform.forward * -1) * speed, ForceMode.Impulse);
        }
    }
}

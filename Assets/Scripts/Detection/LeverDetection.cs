using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LeverDetection : MonoBehaviour
{
    // Variables
    [Header("UNITY EVENT")]
    [Space(10)]
    public UnityEvent leverOn;
    
    [Space(15), Header("LEVER TRANSFORM PARAMS")]
    [SerializeField] private Transform leverTransform;
    [SerializeField] private Vector3 leverPos;
    [SerializeField] private Quaternion leverRot;
    
    [Space(15), Header("MESH && MATERIALS PARAMS")]
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material leverOriginalMat;
    [SerializeField] private Material leverActivateMat;

    private void Awake()
    {
        // Capturing Mesh Renderer && Setting Default Mat
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = leverOriginalMat;
        
        // Capturing the lever starter position
        leverTransform = gameObject.transform;
        leverPos = leverTransform.position;
        leverRot = leverTransform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeverOn"))
        {
            meshRenderer.material = leverActivateMat;
            ResetLeverTransform();
            leverOn.Invoke();
        }
       
        if (other.CompareTag("LeverOff"))
        {
            meshRenderer.material = leverOriginalMat;
        }
    }

    public void ResetLeverTransform()
    {
        gameObject.transform.position = leverPos;
        gameObject.transform.rotation = leverRot;
        meshRenderer.material = leverOriginalMat;
    }
}

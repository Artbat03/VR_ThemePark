using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dardo : MonoBehaviour
{

    public float speed;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    


    public void ApplyVelocity()
    {
        rb.AddForce((transform.forward * -1)  * speed, ForceMode.Impulse);
    }
}

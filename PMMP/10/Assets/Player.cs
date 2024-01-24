using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed = 5;
     private Renderer sphereRenderer;
    private Rigidbody rb;
    private bool isInTrigger = false;

    void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");
        float moverJump = Input.GetAxis("Jump");
        Vector3 movement = new Vector3(moveHorizontal,moverJump*2,moverVertical);
        var rotated = Camera.main.transform.rotation * movement;
        rb.AddForce(rotated* speed);
    }

    void FixedUpdate()
    {
        if (isInTrigger)
        {
            sphereRenderer.material.color = Color.red;
        }
        else
        {
            sphereRenderer.material.color = Color.white;
        }
    }
   

   void OnTriggerEnter(Collider other)
    {
        
            isInTrigger = true;
        
    }

    void OnTriggerExit(Collider other)
    {
        
        
            isInTrigger = false;
        
    }

    
}

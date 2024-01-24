using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
     private Renderer sphereRenderer;
    private Rigidbody rb;
    void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        sphereRenderer.material.color = randomColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");
        float moverJump = Input.GetAxis("Jump");
        Vector3 movement = new Vector3(moveHorizontal,moverJump*2,moverVertical);
        rb.AddForce(movement* speed);
         if (Input.anyKeyDown)
        {
            // Изменяем цвет при каждом нажатии клавиши
            ChangeColor();
        }
    }

    void ChangeColor()
    {
       Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    
       sphereRenderer.material.color = randomColor;
    }
}

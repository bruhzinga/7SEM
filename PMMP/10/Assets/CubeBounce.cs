using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            Debug.Log("Collision with floor");
        }
        if(collision.gameObject.name == "Wall")
        {
            Debug.Log("Collision with wall");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

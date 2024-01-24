using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.GetComponent<Rigidbody>() != null)
       {
              Destroy(collision.gameObject);
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

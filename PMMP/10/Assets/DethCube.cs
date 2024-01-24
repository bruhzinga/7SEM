using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethCube : MonoBehaviour
{
    



    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the floor
        if (collision.gameObject.CompareTag("Floor"))
        {
            // Destroy the object
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
               Destroy(collision.gameObject);
        }
    }


}

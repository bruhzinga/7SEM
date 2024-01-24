using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    //Назначьте верхнему кубу скрипт, который при соприкосновении с объектом придаст объекту силу AddForce в горизонтальном направлении.

    void OnCollisionEnter(Collision collision)
    {
         

        //check if the object you collided with has a rigidbody
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            //add force to the object you collided with
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 500);
        }
    }

    void Update()
    {
        
    }
}

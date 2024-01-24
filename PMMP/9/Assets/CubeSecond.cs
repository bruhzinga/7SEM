using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSecond : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,Time.deltaTime);
    }
}

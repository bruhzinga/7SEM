using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    private MeshRenderer render;
    
    // Start is called before the first frame update
    void Start()
    {
         render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    

    float minX = render.bounds.min.x;
    float maxX = render.bounds.max.x;

    float minZ = render.bounds.min.z;
    float maxZ = render.bounds.max.z;

    float minY = render.bounds.min.y;
    float maxY = gameObject.transform.position.y+10;


    float newX = Random.Range(minX,maxX);
    float newZ = Random.Range(minZ,maxZ);
    float newY = Random.Range(minY,maxY);


   



    if(Input.GetKeyDown(KeyCode.Space)){
        GameObject cubb = GameObject.CreatePrimitive (PrimitiveType.Cube);
        cubb.transform.position = new Vector3(newX,newY,newZ);
        cubb.AddComponent<Rigidbody>();
    }
   if (Input.GetMouseButtonDown(0)) {
    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    sphere.transform.position = new Vector3(newX, Random.Range(newY, newY + 20), newZ);
    Renderer sphereRenderer = sphere.GetComponent<Renderer>();
    
    // Normalize the color values
    Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    
    sphereRenderer.material.color = randomColor;
    sphere.AddComponent<Rigidbody>();
}

    }
}

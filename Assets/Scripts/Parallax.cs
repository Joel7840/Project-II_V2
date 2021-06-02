using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    private float startPos;
    public GameObject cam;
    public float YOffset;
    public float parallaxEffectX;
    public float parallaxEffectY;
    // Start is called before the first frame update
    void Start()
    {                
        startPos = transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float distX = cam.transform.position.x * parallaxEffectX;
        float distY = cam.transform.position.y * parallaxEffectY;

        transform.position = new Vector3(startPos + distX, (startPos - YOffset) + distY, transform.position.z);

        
    }
}

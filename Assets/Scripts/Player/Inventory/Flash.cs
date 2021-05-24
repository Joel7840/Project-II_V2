using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    GameObject flash => gameObject;
    private float timer;
    public float maxTime;
    public float flashIntensityTime;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer < flashIntensityTime)
        {
            flash.gameObject.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().pointLightOuterRadius = timer * 30;
        }        
        if (timer > maxTime)
        {
            Destroy(gameObject);
        }
    }
}

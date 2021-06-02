using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    //Variables privadas-----------------------------------


    //Variables publicas-----------------------------------
    
    public static GameObject cam;
    public static CameraShake instance;
    //Funciones--------------------------------------------

    private void Awake()
    {
        instance = this;
        cam = GameObject.Find("Main Camera");
    }
    //Funcion que activa la coroutine al sentir el shake
    
    public static void DoShake(float d, float m)
    {
        instance.StartCoroutine(Shake(d,m));
    }

    //Coroutine que genera el efecto de Shake
    public static IEnumerator Shake(float _duration, float _magnitude)
    {
        float elapsed = 0.00f;

        while (elapsed < _duration)
        {
            Vector2 ShakePos = UnityEngine.Random.insideUnitCircle * _magnitude;

            cam.transform.position = new Vector3(cam.transform.position.x + ShakePos.x, cam.transform.position.y + ShakePos.y, cam.transform.position.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        
    }
	



}

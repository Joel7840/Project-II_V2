using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource AudioSrc;
   
    // Start is called before the first frame update
    void Start()
    {
        
        AudioSrc = GetComponent<AudioSource>();
        
        /*para reproducir el audio es PlaySound("NOMBRE DEL CLIP DE AUDIO", TRUE/FALSE PARA ACTIVAR EL LOOP)
         el clip tiene que estar en la carpeta Resources*/
        PlaySound("Horror", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    public static void PlaySound(string clip, bool loop)
    {
        AudioSrc.clip = Resources.Load<AudioClip>(clip);
        AudioSrc.loop = loop;
        AudioSrc.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public GameObject menu;
    public GameObject Light;
    
    
    public void Play()
    {
        Light.SetActive(false);        
        Invoke("MakeTransition", 0);
        Invoke("PlayTimer", 2);
        
    }

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }

    void PlayTimer()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void MakeTransition()
    {        
        menu.GetComponent<Animator>().SetBool("Enabled", true);
    }

   
}

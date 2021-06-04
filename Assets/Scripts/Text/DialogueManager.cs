using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static GameObject _textPanel;
    public static GameObject _textBox;

    
    private static Animator anim;

    private static string _text;
    private static float timer;
    private static float maxTime;
    private static bool active;
    
    // Start is called before the first frame update
    void Start()
    {
        _textPanel = GameObject.Find("TextBackground");        
        _textBox = GameObject.Find("TextBox");
        anim = _textPanel.GetComponent<Animator>();
        active = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            timer += Time.deltaTime;
        }
        
        if(timer > maxTime)
        {
            active = false;
            timer = 0;
            anim.SetBool("Open", false);
        }
        
    }

    public static void ChangeText(int i, float time)
    {
        maxTime = time;
        anim.SetBool("Open", true);
        active = true;
        switch (i)
        {
            case 1:
                _text = "TEXT A";
                break;
            case 2:
                _text = "TEXT B";
                break;
            case 3:
                _text = "TEXT C";
                break;
            default:
                _text = "";
                break;
        }

        _textBox.GetComponent<Text>().text = _text;
        
    }
    
    
    
}

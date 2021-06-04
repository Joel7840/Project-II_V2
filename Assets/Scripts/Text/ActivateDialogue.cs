using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogue : MonoBehaviour
{
    private PlayersManager PM;    

    public int text;
    public float time;
    public Color color;
    public GameObject panel;
    public GameObject textbox;

    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlayerClose())
        {
            DialogueManager.ChangeText(text, time, color, panel, textbox);
            Destroy(gameObject);
        }
    }

    private bool IsPlayerClose()
    {        

        return Vector3.Distance(PM.Players[0].transform.position, gameObject.transform.position) < 1;


    }
}

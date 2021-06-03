using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niebla : MonoBehaviour
{
    private PlayersManager PM;    
    public GameObject niebla;
    public bool mistRight;
    void Start()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
    }

    
    void Update()
    {
        if (PM.Players.Count != 0)
        {
            if(mistRight)
            {
                if (IsPlayerDetectedLeft())
                {
                    niebla.SetActive(false);
                }
                if (IsPlayerDetectedRight())
                {
                    niebla.SetActive(true);
                }
            }

            else
            {
                if (IsPlayerDetectedLeft())
                {
                    niebla.SetActive(true);
                }
                if (IsPlayerDetectedRight())
                {
                    niebla.SetActive(false);
                }
            }
            
        }
    }

    private bool IsPlayerDetectedLeft()
    {
        return gameObject.transform.position.magnitude < PM.Players[0].transform.position.magnitude;

    }

    private bool IsPlayerDetectedRight()
    {
        return gameObject.transform.position.magnitude > PM.Players[0].transform.position.magnitude;

    }
}

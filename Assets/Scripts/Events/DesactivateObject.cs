using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateObject : MonoBehaviour
{
    public GameObject g;
    private PlayersManager PM;
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
            g.SetActive(false);
        }
    }

    private bool IsPlayerClose()
    {

        return Vector3.Distance(PM.Players[0].transform.position, gameObject.transform.position) < 1;


    }
}

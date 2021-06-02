using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    PlayersManager PM;    

    private Transform _Player;
    public GameObject _Train;
    public float _PlayerDistance;
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.Players.Count != 0 && IsPlayerClose())
        {
            _Train.GetComponent<Animator>().SetTrigger("Switch");            
            
        }

    }

    private bool IsPlayerClose()
    {
        _Player = PM.Players[0].transform;

        return Vector3.Distance(_Player.position, gameObject.transform.position) < _PlayerDistance;

    }

    
}

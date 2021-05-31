using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    PlayersManager PM;

    private Transform _Player;
    public List<GameObject> eventObjects;
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
            for(int i = 0; i < eventObjects.Count; i++)
            {
                eventObjects[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            
        }       
           
    }

    private bool IsPlayerClose()
    {
        _Player = PM.Players[0].transform;

        return Vector3.Distance(_Player.position, gameObject.transform.position) < _PlayerDistance;

    }
}

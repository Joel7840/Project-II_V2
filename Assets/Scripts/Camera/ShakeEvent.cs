using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEvent : MonoBehaviour
{
    static CameraFollow CF;
    PlayersManager PM;

    private Transform _Player;
    public float _PlayerDistance;
    public float duration;
    public float magnitude;

    void Start()
    {
        CF = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
    }

    private void Update()
    {
        if(IsPlayerClose())
        {
            Activate(duration, magnitude);

        }
    }

    private bool IsPlayerClose()
    {
        _Player = PM.Players[0].transform;

        return Vector3.Distance(_Player.position, gameObject.transform.position) < _PlayerDistance;

    }
    public void Activate(float d, float m)
    {
        CF.Shake(d, m);        
        Destroy(gameObject);
    }

    
}

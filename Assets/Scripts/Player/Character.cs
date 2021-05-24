using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Lighter lighter;
    private PlayersManager PM;

    public GameObject ligtherPrefab;
    public GameObject radioPrefab;
    public GameObject noseDetectorPrefab;
    public GameObject lightPrefab;
    private GameObject _player;
    private Vector3 targetPosition;
    private Vector3 playerPosition;
    public bool kill;

    // Start is called before the first frame update
    void Awake()
    {

        _player = GameObject.Find("Players").transform.GetChild(0).gameObject;
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
    }
    void Start()
    {
        InstantiateLighter();
        InstantiateSomething(radioPrefab);
        InstantiateSomething(lightPrefab);
        //InstantiateNoiseDetector();
        kill = false;        

    }

    // Update is called once per frame
    void Update()
    {
        if (PM.Players.Count != 0)
        {
            if (kill)
            {
                if (_player != PM.Players[0])
                {
                    _player = PM.Players[0];
                    InstantiateLighter();
                    InstantiateSomething(radioPrefab);
                    InstantiateSomething(lightPrefab);
                    //InstantiateNoiseDetector();
                }
                kill = false;
            }
            playerPosition = GameObject.Find("Players").transform.GetChild(0).transform.position;
            targetPosition = GetMouseWorldPosition();
            Vector3 aimDir = (targetPosition - playerPosition).normalized;
            lighter.SetAimDirection(aimDir);
            lighter.SetOrigin(playerPosition);
        }
        
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }

    public void InstantiateLighter()
    {
        Instantiate(ligtherPrefab, _player.transform.position, _player.transform.rotation, _player.transform);
        lighter = _player.transform.GetChild(0).gameObject.GetComponentInChildren<Lighter>();
        _player.transform.GetChild(0).gameObject.GetComponentInChildren<Lighter>().gameObject.SetActive(false);      
        
    }

    public void InstantiateSomething(GameObject g)
    {
        Instantiate(g, _player.transform.position, _player.transform.rotation, _player.transform);
        
    }
    


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StairsManager : MonoBehaviour
{
    PlayersManager PM;
    public bool StairsEnabled;
    private float maxDistance = 1;
    public bool RoofEnabled;
    public bool StairsDirection;
    public bool StairsOff;
    public bool StairsAndRoofOff;
    private float angleOffset;
    private GameObject _Player;
    public GameObject _Stair;
    public GameObject _RoofStairs;
    public GameObject _StairsDown;
    public GameObject _StairsUp;
    

    
    void Awake()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(StairsDirection)
        {
            angleOffset = -1f;
        }
        else
        {
            angleOffset = 1f;
        }
        _Player = PM.Players[0].gameObject;
        
        if(StairsAndRoofOff)
        {
            IgnoreCollisionsStart(_Stair.GetComponent<Collider2D>(), true);
            StairsEnabled = false;

            IgnoreCollisionsStart(_RoofStairs.GetComponent<Collider2D>(), false);
            RoofEnabled = true;
        }
        else
        {
            if (!StairsOff)
            {
                IgnoreCollisionsStart(_Stair.GetComponent<Collider2D>(), true);
                StairsEnabled = false;

                IgnoreCollisionsStart(_RoofStairs.GetComponent<Collider2D>(), true);
                RoofEnabled = false;
            }
            else
            {
                IgnoreCollisionsStart(_Stair.GetComponent<Collider2D>(), false);
                StairsEnabled = true;

                IgnoreCollisionsStart(_RoofStairs.GetComponent<Collider2D>(), false);
                RoofEnabled = true;
            }
        }
        
        

        IgnoreCollisionsEnemies(_Stair.GetComponent<Collider2D>(), true);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (PM.Players.Count != 0)
        {
            _Player = PM.Players[0].gameObject;
        
            if (PlayerClose(_StairsDown) && Input.GetKeyDown("e"))
            {

                if (StairsEnabled == true)
                {
                    IgnoreCollisionsStart(_Stair.GetComponent<Collider2D>(), true);
                    StairsEnabled = false;
                    _StairsDown.transform.Rotate(0.0f, 0.0f, -45.0f * angleOffset);

                    IgnoreCollisionsStart(_RoofStairs.GetComponent<Collider2D>(), false);
                    RoofEnabled = true;
                    _StairsUp.transform.Rotate(0.0f, 0.0f, -45.0f * angleOffset);
                }
                else
                {
                    IgnoreCollisionsStart(_Stair.GetComponent<Collider2D>(), false);
                    StairsEnabled = true;
                    _StairsDown.transform.Rotate(0.0f, 0.0f, 45.0f * angleOffset);

                    IgnoreCollisionsStart(_RoofStairs.GetComponent<Collider2D>(), true);
                    RoofEnabled = false;
                    _StairsUp.transform.Rotate(0.0f, 0.0f, 45.0f * angleOffset);
                }
            }

            if (PlayerClose(_StairsUp) && Input.GetKeyDown("e"))
            {
                if (RoofEnabled == false)
                {
                    IgnoreCollisionsStart(_RoofStairs.GetComponent<Collider2D>(), false);
                    RoofEnabled = true;
                    _StairsUp.transform.Rotate(0.0f, 0.0f, -45.0f * angleOffset);

                    IgnoreCollisionsStart(_Stair.GetComponent<Collider2D>(), true);
                    StairsEnabled = false;
                    _StairsDown.transform.Rotate(0.0f, 0.0f, -45.0f * angleOffset);
                }
                else
                {
                    IgnoreCollisionsStart(_RoofStairs.GetComponent<Collider2D>(), true);
                    RoofEnabled = false;
                    _StairsUp.transform.Rotate(0.0f, 0.0f, 45.0f * angleOffset);

                    IgnoreCollisionsStart(_Stair.GetComponent<Collider2D>(), false);
                    StairsEnabled = true;
                    _StairsDown.transform.Rotate(0.0f, 0.0f, 45.0f * angleOffset);
                }
            }
        }
        
        

    }

    

    private void IgnoreCollisions(Collider2D col, bool enable)
    {
        Debug.Log(PM.Players.Count);
        for (int i = 0; i < PM.Players.Count; i++)
        {
            Physics2D.IgnoreCollision(PM.Players[i].GetComponent<Collider2D>(), col, enable);
            
        }
    }

    private void IgnoreCollisionsStart(Collider2D col, bool enable)
    {
        
        for (int i = 0; i < PM.Allys.Count; i++)
        {
            Physics2D.IgnoreCollision(PM.Allys[i].GetComponent<Collider2D>(), col, enable);

        }
    }

    private void IgnoreCollisionsEnemies(Collider2D col, bool enable)
    {

        for (int i = 0; i < PM.Enemies.Count; i++)
        {
            Physics2D.IgnoreCollision(PM.Enemies[i].GetComponent<Collider2D>(), col, enable);

        }
    }

    private bool PlayerClose(GameObject UpDown)
    {
        var dist = Vector3.Distance(UpDown.transform.position, _Player.transform.position);
        return dist < maxDistance;
    }
        
}

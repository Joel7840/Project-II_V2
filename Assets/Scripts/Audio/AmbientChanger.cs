using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientChanger : MonoBehaviour
{
    private PlayersManager PM;
    public LayerMask player;
    public string sonido1;
    public string sonido2;

    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PM.Players.Count != 0)
        {
            if (IsPlayerDetectedLeft())
            {
                AudioManager.PlayAmbient(sonido1);
            }
            if (IsPlayerDetectedRight())
            {
                AudioManager.PlayAmbient(sonido2);
            }
        }
    }
    private bool IsPlayerDetectedLeft()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left,
            0.5f, player);
        return hit.collider == PM.Players[0].GetComponent<Collider2D>();

    }

    private bool IsPlayerDetectedRight()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right,
            0.5f, player);
        return hit.collider == PM.Players[0].GetComponent<Collider2D>();

    }
}

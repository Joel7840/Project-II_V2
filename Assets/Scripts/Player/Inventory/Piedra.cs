using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piedra : MonoBehaviour
{
    private PlayersManager PM;
    private PlayerMovement PMove;

    public float dist;
    public float direction;

    private AudioSource SFXpiedra;

    // Start is called before the first frame update
    void Start()
    {
        PMove = GameObject.Find("Players").GetComponent<PlayerMovement>();
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Direction(), 0);
        SFXpiedra = GameObject.Find("PiedraSFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CheckEnemies()
    {
        for(int i = 0; i < PM.Enemies.Count; i++)
        {
            if((PM.Enemies[i].transform.position - gameObject.transform.position).magnitude < dist)
            {
                if(PM.Enemies[i].layer == 12)
                {
                    PM.Pposition = gameObject.transform.position;
                }
                PM.Enemies[i].GetComponent<Animator>().SetBool("Attract", true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            AudioManager.PlaySFX("piedra", SFXpiedra);
            CheckEnemies();
            Destroy(gameObject);
        }
    }

    private float Direction()
    {
        if(PMove.Right)
        {
            return 10;
        }
        else
        {
            return -10;
        }
    }
}

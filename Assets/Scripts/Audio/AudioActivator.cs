using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioActivator : MonoBehaviour
{
    private PlayersManager PM;
    private AudioManager AM;
    public LayerMask player;
    public string sonido1;
    public string sonido2;

    public float sonido1Volumen;
    public float sonido2Volumen;

    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        AM = GameObject.Find("SoundManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.Players.Count != 0)
        {
            if (IsPlayerDetectedLeft())
            {
                AM.GlobalMusicVolume = sonido1Volumen;
                AudioManager.PlayMusic(sonido1);
            }
            if (IsPlayerDetectedRight())
            {
                AM.GlobalMusicVolume = sonido2Volumen;
                AudioManager.PlayMusic(sonido2);
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

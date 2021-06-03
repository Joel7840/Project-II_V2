using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoise : MonoBehaviour
{
    PlayersManager PM;    

    private Transform _player;

    public float playerMaxDistance;
    public int enemyType;    
    private int maxTime;
    private float timer;

    private bool sound;

    private AudioSource SFXenemy;

    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        _player = PM.Players[0].transform;
        ChoseSFX();
        timer = 0;
        sound = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlayerClose())
        {
            
            if (sound)
            {
                maxTime = Random.Range(5, 7);
                sound = false;
            }
            timer += Time.deltaTime;
            if(timer > maxTime)
            {
                PlaySound();
                
            }
            
        }
        
    }

    private bool IsPlayerClose()
    {
        _player = PM.Players[0].transform;
        return (_player.position - gameObject.transform.position).magnitude < playerMaxDistance;
    }

    private void ChoseSFX()
    {
        if (enemyType == 1) { SFXenemy = GameObject.Find("DemonioSFX").GetComponent<AudioSource>(); }
        else if (enemyType == 2) { SFXenemy = GameObject.Find("CascabelSFX").GetComponent<AudioSource>(); }
        else { SFXenemy = GameObject.Find("AngelSFX").GetComponent<AudioSource>(); }
    }

    private void PlaySound()
    {
        if (enemyType == 1) { AudioManager.PlaySFX("grito_demonio", SFXenemy); }
        else if (enemyType == 2) { AudioManager.PlaySFX("grito_cascabel", SFXenemy); }
        else { AudioManager.PlaySFX("grito_angel", SFXenemy); }
        timer = 0;
        sound = true;


    }
}

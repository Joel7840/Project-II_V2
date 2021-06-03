using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    PlayersManager PM;
    private float maxDistance = 2;
    private GameObject door => gameObject;
    private GameObject Player;
    public GameObject Out;
    public GameObject In;

    public Sprite DoorOpen;
    public Sprite DoorClose;    

    public GameObject DoorSprite;
    

    public bool closed = true;
    public bool metalDoor;    

    private AudioSource SFXpuerta;
    
    // Start is called before the first frame update

    void Awake()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        
    }
    void Start()
    {
        Player = PM.Players[0].gameObject;
        SFXpuerta = GameObject.Find("PuertaSFX").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.Players.Count != 0)
        {
            Player = PM.Players[0].gameObject;

            if ((PlayerClose(In) || PlayerClose(Out)) && Input.GetKeyDown("e"))
            {

                if (closed)
                {
                    IgnoreCollisions(closed);
                    if(metalDoor)
                    {
                        AudioManager.PlaySFX("abrir_puerta_metal", SFXpuerta);
                    }
                    else
                    {
                        AudioManager.PlaySFX("abrir_puerta_madera", SFXpuerta);
                    }
                    
                    //ChangeSpriteToOpen();

                }
                else
                {
                    IgnoreCollisions(closed);
                    if (metalDoor)
                    {
                        AudioManager.PlaySFX("cerrar_puerta_metal", SFXpuerta);
                    }
                    else
                    {
                        AudioManager.PlaySFX("cerrar_puerta_madera", SFXpuerta);
                    }
                    //ChangeSpriteToClose();

                }

            }
        }
        
    }

    private void IgnoreCollisions(bool enable)
    {
        Debug.Log(PM.Players.Count);
        door.GetComponent<Collider2D>().enabled = !enable;
        closed = !closed;
    }

    private bool PlayerClose(GameObject InOut)
    {
        var dist = Vector3.Distance(InOut.transform.position, Player.transform.position);        
        return dist < maxDistance;
    }

    private void ChangeSpriteToOpen()
    {
        DoorSprite.GetComponent<SpriteRenderer>().sprite = DoorOpen;
        
    }

    private void ChangeSpriteToClose()
    {
        DoorSprite.GetComponent<SpriteRenderer>().sprite = DoorClose;
        
    }
}

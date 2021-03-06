using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayersManager PM;
    
    //private List<GameObject> Players = new List<GameObject>();
    public float Speed;    
    public float NormalSpeed;
    public float speedChange;    
    public float playerMaxDist = 0.5f;    
    public float speedFast;
    public float speedSlow;

    public bool Right;
    public static bool movement;

    private AudioSource SFXpaso;
    public float SFXspeedFast;
    public float SFXspeedSlow;
    private GameObject Player => GameObject.Find("Player");
    

    //private float _horizontal = 1;
    // Start is called before the first frame update
    void Awake()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
    }

    private void Start()
    {
        Right = true;
        movement = true;
        SFXpaso = GameObject.Find("PasoSFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void Move()
    {
        if (PM.Players.Count != 0 && movement)
        {
            WalkSFX();
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedChange = speedFast;
                SFXpaso.pitch = SFXspeedFast;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                speedChange = speedSlow;
                SFXpaso.pitch = SFXspeedSlow;
            }
            else
            {
                speedChange = 0;
                SFXpaso.pitch = 1;
            }



            if (Input.GetKey("d"))
            {                
                Speed = NormalSpeed + speedChange;
                Right = true;
            }
            else if (Input.GetKey("a"))
            {
                Speed = -NormalSpeed - speedChange;
                Right = false;
            }
            else
            {
                Speed = 0;
                SFXpaso.Stop();

            }





            Vector2 vel1 = PM.Players[0].GetComponent<Rigidbody2D>().velocity;
            vel1.x = Speed;
            PM.Players[0].GetComponent<Rigidbody2D>().velocity = vel1;

            if (PM.Players.Count > 1)
            {
                for (int i = 1; i < PM.Players.Count; i++)
                {
                    if ((PM.Players[i].transform.position - PM.Players[i - 1].transform.position).magnitude > playerMaxDist && PM.Players[i] != null)
                    {
                        Vector2 vel = PM.Players[i].GetComponent<Rigidbody2D>().velocity;
                        vel.x = Speed;
                        PM.Players[i].GetComponent<Rigidbody2D>().velocity = vel;
                    }

                }
            }
        }
        
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        
        if (collision.gameObject.layer == 8)
        {
            if(PM.Players.Count > 2)
            {
                int side;
                if (PM.Players[PM.Players.Count - 1].transform.position.magnitude < PM.Players[PM.Players.Count - 2].transform.position.magnitude)
                {
                    side = -1;
                }
                else
                {
                    side = 1;
                }
                collision.gameObject.transform.position = PM.Players[PM.Players.Count - 1].transform.position - new Vector3(side * 0.5f, 0, 0);
                PM.Players.Add(collision.gameObject);
                collision.gameObject.layer = 3;
            }
            else
            {
                collision.gameObject.transform.position = PM.Players[PM.Players.Count - 1].transform.position - new Vector3(0.5f, 0, 0);
                PM.Players.Add(collision.gameObject);
                collision.gameObject.layer = 3;
            }
            
            

        }
    }

    private void WalkSFX()
    {
        if(Input.GetKeyDown("d") || Input.GetKeyDown("a"))
        {
            AudioManager.PlaySFX("paso", SFXpaso);
        }        
        
    }

    
    
}

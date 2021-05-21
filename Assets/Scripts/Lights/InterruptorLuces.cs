using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorLuces : MonoBehaviour
{
    public List<GameObject> lightsOut;
    public List<GameObject> lightsIn;
    public LayerMask player;
    private PlayersManager PM;
    private CameraFollow CF;
    public bool doorLeft;
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        CF = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.Players.Count != 0)
        {
            if (doorLeft)
            {
                if (IsPlayerDetectedLeft())
                {
                    TurnLightsOff(lightsOut);
                    TurnLightsOn(lightsIn);
                    ZoomIn();
                }
                if (IsPlayerDetectedRight())
                {
                    TurnLightsOn(lightsOut);
                    TurnLightsOff(lightsIn);
                    ZoomOut();
                }
            }
            else
            {
                if (IsPlayerDetectedLeft())
                {
                    TurnLightsOn(lightsOut);
                    TurnLightsOff(lightsIn);
                    ZoomOut();
                }
                if (IsPlayerDetectedRight())
                {
                    TurnLightsOff(lightsOut);
                    TurnLightsOn(lightsIn);
                    ZoomIn();
                }
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

    private void TurnLightsOn(List<GameObject> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().enabled = true;
        }
    }

    private void TurnLightsOff(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().enabled = false;
        }
    }

    private void ZoomOut()
    {
        Camera.main.orthographicSize = 3f;
        CF.YOffset = 1.5f;
    }

    private void ZoomIn()
    {
        Camera.main.orthographicSize = 1.5f;
        CF.YOffset = 0.3f;
    }
}

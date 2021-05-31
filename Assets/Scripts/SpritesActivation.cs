using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesActivation : MonoBehaviour
{
    public List<GameObject> roomUpSprites;
    public List<GameObject> roomDownSprites;
    private GameObject _Player;
    private PlayersManager PM;
    public float _PlayerMaxDist;
    public bool stairsDown;
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.Players.Count != 0 && IsPlayerClose())
        {
            if(_Player.transform.position.y < gameObject.transform.position.y)
            {
                DesactivateSprites(roomUpSprites);
                ActivateSprites(roomDownSprites);
            }

            else
            {
                DesactivateSprites(roomDownSprites);
                ActivateSprites(roomUpSprites);
            }
        }

    }

    private bool IsPlayerClose()
    {
        _Player = PM.Players[0];

        return Vector3.Distance(_Player.transform.position, gameObject.transform.position) < _PlayerMaxDist;


    }

    private void DesactivateSprites(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void ActivateSprites(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}

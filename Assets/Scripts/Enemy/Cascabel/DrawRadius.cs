using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRadius : MonoBehaviour
{
    Animator anim;
    PlayerMovement PMove;
    public float _PlayerMaxDist;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        PMove = GameObject.Find("Players").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    

    private void ChangePMD(Animator anim)
    {
        if (PMove.speedChange == PMove.speedSlow)
        {
            _PlayerMaxDist = anim.GetFloat("PMDslow");
        }
        else if (PMove.speedChange == PMove.speedFast)
        {
            _PlayerMaxDist = anim.GetFloat("PMDfast");
        }
        else
        {
            _PlayerMaxDist = anim.GetFloat("PMDstandard");
        }
    }

    void OnDrawGizmos()
    {
        if(Application.isPlaying)
        {
            ChangePMD(anim);
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(anim.transform.position, _PlayerMaxDist);
        }
        
    }
}

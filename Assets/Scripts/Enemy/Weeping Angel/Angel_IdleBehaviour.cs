using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel_IdleBehaviour : StateMachineBehaviour
{
    PlayersManager PM;
    public float playerMaxDistance;
    private Transform _player;
    public LayerMask lighter;
    private Animator anim;
    



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        _player = PM.Players[0].transform;
        anim = animator;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PM.Players.Count != 0)
        {
            var lightClose = (IsLightDetectedRight(0.3f) || IsLightDetectedLeft(0.3f)) || (IsLightDetectedRight(2f) && IsLightDetectedLeft(2f));
            var playerClose = IsPlayerClose();

            animator.SetBool("IsChasing", !lightClose && playerClose);
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    private bool IsPlayerClose()
    {
        _player = PM.Players[0].transform;
        return (_player.position - anim.gameObject.transform.position).magnitude < playerMaxDistance;
    }

    private bool IsLightDetectedRight(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(anim.transform.position, Vector2.right,
            distance, lighter);
        return hit.collider != null;
    }

    private bool IsLightDetectedLeft(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(anim.transform.position, Vector2.left,
            distance, lighter);
        return hit.collider != null;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cascabel_ChaseBehaviour : StateMachineBehaviour
{
    
    public float Speed = 2;

    PlayersManager PM;
    PlayerMovement PMove;
    private Transform _Player;
    private Transform _gameObject;
    public float _PlayerMaxDist;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _PlayerMaxDist = animator.GetFloat("PMDstandard");
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        PMove = GameObject.Find("Players").GetComponent<PlayerMovement>();
        _Player = PM.Players[0].transform;
        _gameObject = animator.gameObject.transform;

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (PM.Players.Count != 0)
        {
            ChangePMD(animator);
            var noiseHeard = IsPlayerClose() && (IsPlayerMoving() || IsRadioOn());

            animator.SetBool("IsIdle", !noiseHeard);

            Vector2 dir = _Player.position - animator.transform.position;
            animator.transform.position += (Vector3)dir.normalized * Speed * Time.deltaTime;
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsChasing", false);
    }

    private bool IsPlayerClose()
    {
        _Player = PM.Players[0].transform;

        return Vector3.Distance(_Player.position, _gameObject.position) < _PlayerMaxDist;

    }

    private bool IsPlayerMoving()
    {

        return _Player.GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0);
    }

    private bool IsRadioOn()
    {

        return _Player.transform.GetChild(1).GetComponent<Radio>().On == true;
    }

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
}

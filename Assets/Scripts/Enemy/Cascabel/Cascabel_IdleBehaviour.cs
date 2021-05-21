using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cascabel_IdleBehaviour : StateMachineBehaviour
{
    public float StayTime;


    private float _timer;

    PlayersManager PM;
    private GameObject _Player;
    private Transform _gameObject;
    public float _PlayerMaxDist;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        _timer = 0;

        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        _Player = PM.Players[0];
        _gameObject = animator.gameObject.transform;
        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        var timeUp = IsTimeUp();


        var playerClose = IsPlayerClose() && (IsPlayerMoving() || IsRadioOn());

        animator.SetBool("IsChasing", playerClose);
        animator.SetBool("IsPatroling", timeUp);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsIdle", false);
    }

    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return _timer > StayTime;
    }



    private bool IsPlayerClose()
    {
        _Player = PM.Players[0];

        return Vector3.Distance(_Player.transform.position, _gameObject.position) < _PlayerMaxDist;


    }

    private bool IsPlayerMoving()
    {

        return _Player.GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0);
    }

    private bool IsRadioOn()
    {

        return _Player.transform.GetChild(1).GetComponent<Radio>().On == true;
    }



}

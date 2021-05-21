using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio_DistractBehaviour : StateMachineBehaviour
{
    PlayersManager PM;
    public float Speed = 2;
    private Transform _player;
    private float _timer;
    public float StayTime;

    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        _player = PM.Players[0].transform;
        _timer = 0;

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        var timeUp = IsTimeUp();


        animator.SetBool("IsIdle", timeUp);




        Vector2 dir =  animator.transform.position - _player.position;
        animator.transform.position += (Vector3)dir.normalized * Speed * Time.deltaTime;

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Distract", false);
        
    }

    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return _timer > StayTime;
    }


}

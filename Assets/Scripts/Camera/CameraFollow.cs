using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    PlayersManager PM;
    PlayerMovement PMove;
    private Transform cameraTransform => gameObject.transform;
    private Transform Target;
    public float Z;
    public float YOffset;
    private float XOffset;
    
    private Vector3 camVel;
    [Range(0, 1)]
    public float globalSmoothing;
    private bool direction;
    private float timer;
    public bool isShake;

    public AudioSource SFXshake;

    private void Awake()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        PMove = GameObject.Find("Players").GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Target = PM.Players[0].gameObject.transform;
        timer = 0;
        isShake = false;
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PM.Players.Count != 0)
        {
            if(!isShake)
            {
                Target = PM.Players[0].gameObject.transform;
                Follow();
            }     
            
        }
    }

    void Follow()
    {
        timer += Time.deltaTime;
        ChangePos();
        ResetTimer();
        ChangeSmooth();
        Vector3 pos = new Vector3 (Target.position.x + XOffset, Target.position.y + YOffset, Z);
        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, pos, ref camVel, globalSmoothing);
        direction = PMove.Right;
    }

    void ChangePos()
    {
        if (PMove.Right)
        {
            XOffset = 1.5f;
        }
        else
        {
            XOffset = -1.5f;
        }        

    }

    void ChangeSmooth()
    {
        if (timer < 0.2f)
        {
            globalSmoothing = 0.06f;
        }
        else
        {
            globalSmoothing = 0f;
        }
    }
    void ResetTimer()
    {
        if (direction != PMove.Right)
        {
            timer = 0;
        }
    }

    public void Shake(float d, float m)
    {
        PlayerMovement.movement = false;
        isShake = true;
        AudioManager.PlaySFX("terremoto", SFXshake);
        Invoke("StopAudio", 3);
        CameraShake.DoShake(d, m);
        Invoke("ChangeShake", d);

    }

    public void ChangeShake()
    {
        isShake = false;
        PlayerMovement.movement = true;
    }

    private void StopAudio()
    {
        SFXshake.Stop();
    }
}

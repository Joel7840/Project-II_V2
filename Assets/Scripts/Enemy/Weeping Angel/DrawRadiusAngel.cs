using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRadiusAngel : MonoBehaviour
{
    PlayerMovement PMove;
    public float _PlayerMaxDist;
    void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(gameObject.transform.position, _PlayerMaxDist);
        }

    }
}

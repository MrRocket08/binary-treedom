using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RerrGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Animator rAnimator;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (aiPath.desiredVelocity.x > 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x < -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }


    }
}

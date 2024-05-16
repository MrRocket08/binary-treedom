using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 40f;
    public Animator animator;
    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        // input
        movement.x = Input.GetAxisRaw("Horizontal"); // value in {-1, 0, 1} from keyboard
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 0 && movement.y == 0)
        {
            animator.ResetTrigger("RunBack");
            animator.ResetTrigger("RunForward");
            animator.SetTrigger("Idle");
        }
        else if (movement.y > 0)
        {
            animator.ResetTrigger("Idle");
            animator.ResetTrigger("RunForward");
            animator.SetTrigger("RunBack");
        }
        else if (movement.y < 0)
        {
            animator.ResetTrigger("Idle");
            animator.ResetTrigger("RunBack");
            animator.SetTrigger("RunForward");
        }
        else if (movement.x != 0)
        {
            animator.ResetTrigger("Idle");
            animator.ResetTrigger("RunBack");
            animator.SetTrigger("RunForward");
        }
    }

    void FixedUpdate()
    {
        // movement
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}

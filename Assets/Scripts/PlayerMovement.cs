using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 40f;
    public Animator animator;
    Vector2 movement;

    //Dash Ability Class
    public Dash dashAbility;

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

        if (Input.GetMouseButtonDown(2) && dashAbility != null)
        {
            Vector3 mousePositionScreen = Input.mousePosition;
            Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);

            // Check if the current ability is a dash ability
            if (dashAbility != null)
            {
                dashAbility.PerformDash(mousePositionWorld);
            }
        }
    }

    void FixedUpdate()
    {

        // movement
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}

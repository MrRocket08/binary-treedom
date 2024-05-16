using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{


    public Rigidbody2D rb;
    public float moveSpeed = 40f;
    public Animator animator;
    Vector2 movement;


    //Dashing Field Variables
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 48f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    // Update is called once per frame
    void Update()
    {


        //prevents the player from dashing and walking at the same time
        if (isDashing)
        {
            return;
        }


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


        //dashing routine
        if (Input.GetMouseButtonDown(1) && canDash)
        {
            StartCoroutine(Dash());
        }
    }


    void FixedUpdate()
    {
        //preventing player from moving and dashing at the same time
        if (isDashing)
        {
            return;
        }
        // movement
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }


    //Dashing Co-Routine
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        // Calculate direction from player to mouse position
        Vector3 mousePositionScreen = Input.mousePosition;
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
        Vector2 dashDirection = (mousePositionWorld - transform.position).normalized;


        // Apply force for dashing
        rb.velocity = dashDirection * dashingPower;


        yield return new WaitForSeconds(dashingTime);


        rb.velocity = Vector2.zero;
        isDashing = false;


        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}



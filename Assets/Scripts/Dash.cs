using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability
{
    public Rigidbody2D rb;
    public float dashingPower = 48f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    private bool canDash = true;
    private bool isDashing;

    public void PerformDash(Vector3 targetPosition)
    {
        if (!canDash || isDashing)
            return;

        Vector2 dashDirection = (targetPosition - transform.position).normalized;
        rb.velocity = dashDirection * dashingPower;

        StartCoroutine(DashCooldown());
    }

    private IEnumerator DashCooldown()
    {
        canDash = false;
        isDashing = true;
        yield return new WaitForSeconds(dashingTime);
        rb.velocity = Vector2.zero;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
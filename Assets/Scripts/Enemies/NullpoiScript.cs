using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullpoiScript : MonoBehaviour
{
    public GameObject nullpoi;
    public Animator rAnimator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        health = 10;
        defense = 4;
        damage = 5;
        knockback = 40;
        attackCooldown = 4;

        InvokeRepeating("Attack", (float)Random.Range(0, attackCooldown), attackCooldown);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetPos.x = player.transform.position.x;
        targetPos.y = player.transform.position.y;
    }

    public override void Attack()
    {
        Vector2 dashDirection = new Vector2(targetPos.x - rer.transform.position.x, targetPos.y - rer.transform.position.y).normalized;

        rer.GetComponent<Rigidbody2D>().velocity = dashDirection * lungeSpeed;
    }
}

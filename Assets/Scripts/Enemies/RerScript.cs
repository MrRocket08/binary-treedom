using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerScript : Enemy
{
    public GameObject rer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        attackCooldown = 3;
        speed = 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        attackCooldown -= Time.fixedDeltaTime;

        targetPos.x = player.transform.position.x;
        targetPos.y = player.transform.position.y;

        if (attackCooldown <= 0)
        {
            Attack();

            attackCooldown = 3;
        }
    }

    public override void Attack()
    {
        Vector2 dashDirection = new Vector2(targetPos.x - rer.transform.position.x, targetPos.y - rer.transform.position.y).normalized;

        rer.GetComponent<Rigidbody2D>().velocity = dashDirection * speed;
    }
    void OnCollisionEnter2D(Collision2D col) { return; }
}

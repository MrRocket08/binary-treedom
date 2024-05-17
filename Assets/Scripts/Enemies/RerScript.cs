using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerScript : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        attackCooldown = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        attackCooldown -= Time.fixedDeltaTime();

        targetPos.x = player.transform.x;
        targetPos.y = player.transform.y;

        if (attackCooldown <= 0)
        {
            Attack();

            attackCooldown = 3;
        }
    }

    void Attack() { return; }
    void OnCollisionEnter2D(Collider2D col) { return; }
}

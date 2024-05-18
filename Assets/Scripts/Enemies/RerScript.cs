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

        health = 5;
        defense = 0;
        speed = 50;
        damage = 4;
        knockback = 100;
        attackCooldown = 3;
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
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Player"))
        {
            Vector2 knockbackDir = new Vector2(rer.transform.position.x - targetPos.x, rer.transform.position.y - targetPos.y).normalized;

            col.gameObject.GetComponent<Player>().getHit(damage, knockbackDir * knockback);

            knockbackDir *= -1;

            rer.GetComponent<Rigidbody2D>().AddForce(knockbackDir * knockback, ForceMode2D.Impulse);
        }
    }
}

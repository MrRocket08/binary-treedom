using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerrScript : Enemy
{
    public GameObject rer;
    public float lungeSpeed = 40f;
    public RerrAI rAI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        health = 5;
        defense = 0;
        damage = 4;
        knockback = 20;
        attackCooldown = 3;

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
        rAI.Attack(lungeSpeed);
    }

    // works, but goofily
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Vector2 knockbackDir = new Vector2(rer.transform.position.x - targetPos.x, rer.transform.position.y - targetPos.y).normalized;

            col.gameObject.GetComponent<Player>().getHit(damage, knockbackDir * knockback);

            //knockbackDir *= -1;

            //rer.GetComponent<Rigidbody2D>().AddForce(knockbackDir * knockback, ForceMode2D.Impulse);
        }
    }
}

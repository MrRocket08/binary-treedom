using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerrScript : Enemy
{
    public GameObject rer;
    public Animator rAnimator;
    public float lungeSpeed = 40f;

    private int status = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        health = 5;
        defense = 0;
        damage = 4;
        knockback = 20;
        attackCooldown = 3;

        InvokeRepeating("Attack", 0f, attackCooldown);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetPos.x = player.transform.position.x;
        targetPos.y = player.transform.position.y;
    }

    public override void Attack()
    {
        setStatus(2);

        Vector2 dashDirection = new Vector2(targetPos.x - rer.transform.position.x, targetPos.y - rer.transform.position.y).normalized;

        rer.GetComponent<Rigidbody2D>().velocity = dashDirection * lungeSpeed;

        setStatus(1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Vector2 knockbackDir = new Vector2(rer.transform.position.x - targetPos.x, rer.transform.position.y - targetPos.y).normalized;

            col.gameObject.GetComponent<Player>().getHit(damage, knockbackDir * knockback);

            knockbackDir *= -1;

            rer.GetComponent<Rigidbody2D>().AddForce(knockbackDir * knockback, ForceMode2D.Impulse);
        }
    }

    public void setStatus(int _status)
    {
        status = _status;
    }
}

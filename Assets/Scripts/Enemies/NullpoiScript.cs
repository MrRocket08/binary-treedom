using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullpoiScript : Enemy
{
    public GameObject nullpoi;
    public GameObject shootSphere;
    public Animator nAnimator;
    public NullpoiAI npAI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        health = 10;
        defense = 3;
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
        npAI.Attack(shootSphere);
    }
}

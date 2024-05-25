using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullpoiScript : Enemy
{
    public GameObject nullpoi;
    public GameObject shootSphere;
    public Animator nAnimator;
    public NullpoiAI npAI;

    private Vector2 targetDir;

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

        targetDir = new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y).normalized;
    }

    public override void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + targetDir, targetDir, Mathf.Infinity);
        
        if(hit.collider.CompareTag("Player"))
            npAI.Attack(shootSphere);
    }
}

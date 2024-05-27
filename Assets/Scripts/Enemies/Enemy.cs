using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // fields
    protected float health;
    protected int defense;
    protected int damage;
    protected int knockback;
    protected float attackCooldown;
    protected GameObject player;
    protected Vector2 targetPos;
    public SpriteRenderer sp;

    // class methods
    public abstract void Attack();

    public void subtractHealth(int amount)
    {
        health -= amount;

        StartCoroutine(DamageVisuals());

        if (health <= 0)
            Destroy(this.gameObject);
    }
    private IEnumerator DamageVisuals()
    {
        sp.color = Color.red;

        yield return new WaitForSeconds(.1f);

        sp.color = Color.white;
    }
}

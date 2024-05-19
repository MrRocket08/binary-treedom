using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // fields
    protected float health;
    protected int defense;
    protected float speed;
    protected int damage;
    protected int knockback;
    protected float attackCooldown;
    protected GameObject player;
    protected Vector2 targetPos;

    // class methods
    public abstract void Attack();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // fields
    protected float health;
    protected int defense;
    protected int speed;
    protected int damage;
    protected float attackCooldown;
    protected GameObject player;
    protected Vector2 targetPos;

    // class methods
    public abstract void Attack();
}

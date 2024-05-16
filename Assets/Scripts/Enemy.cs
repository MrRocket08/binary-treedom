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

    // class methods
    protected Player Attack()
    { 
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class Enemy : MonoBehaviour
{
    // fields
    protected float health;
    protected int defense;
    protected int speed;
    protected int damage;
    protected AIPath aiPath;

    // class methods
    protected abstract Player Attack() { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    // fields
    private int damage;
    private int damageRange;
    private int useSpeed;
    private float staminaUse;
    private string name;
    private string type;

    // class methods
    public Weapon(string _name, string _type, int _damage, int _damageRange, int _useSpeed, float _staminaUse)
    {
        damage = _damage;
        damageRange = _damageRange;
        useSpeed = _useSpeed;
        staminaUse = _staminaUse;
        name = _name;
        type = _type;
    }

    public Enemy Hit()
    {
        // do something that hits the enemy!
        int dmg = HitDamage();
    }

    public int HitDamage()
    {
        return Random.Range(damage - damageRange, damage + damageRange + 1);
    }

    // accessor methods

    // mutator methods
}

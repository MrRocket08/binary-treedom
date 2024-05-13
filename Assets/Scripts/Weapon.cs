using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    // fields
    private int damage;
    private int damageRange;
    private int useSpeed;
    private string name;
    private string type;

    // class methods
    public Weapon(string _name, string _type, int _damage, int _damageRange, int _useSpeed)
    {
        damage = _damage;
        damageRange = _damageRange;
        useSpeed = _useSpeed;
        name = _name;
        type = _type;
    }

    // accessor methods

    // mutator methods
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    // fields
    protected int damage;
    protected int damageRange;
    protected int useSpeed;
    protected int stamina;
    protected float staminaUse;
    protected string type;

    protected float cooldown = 0;

    // class methods
    public Weapon(string _name, string _type, int _damage, int _damageRange, int _useSpeed, float _staminaUse, int _stamina)
    {
        damage = _damage;
        damageRange = _damageRange;
        useSpeed = _useSpeed;
        staminaUse = _staminaUse;
        name = _name;
        type = _type;
        stamina = _stamina;
    }

    public void Hit()
    {

    }

    public int HitDamage()
    {
        if (staminaUse>=damage+damageRange)
            return Random.Range(damage - damageRange, damage + damageRange + 1);
        else if (staminaUse>=damage-damageRange)
            return (int) Random.Range(damage - damageRange, staminaUse+1);
        return (int) staminaUse;
    }


    // accessor methods

    public string getName(){return name;}
    public string getType(){return type;}
    public int getDamage(){return damage;}
    public int getDamageRange(){return damageRange;}
    public int getUseSpeed(){return useSpeed;}
    public float getStaminaUse(){return staminaUse;}

    // mutator methods
}

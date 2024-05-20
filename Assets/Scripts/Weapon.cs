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

    private bool isOnCooldown = false;

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

    public void Hit(Enemy enemy)
    {
        // do something that hits the enemy!
        
        if (!isOnCooldown){
            int hitDamage = HitDamage();
            staminaUse -= HitDamage();
            if (staminaUse==0)
                CoolDown();
            enemy.subtractHealth(hitDamage);
        }
        
    }

    public int HitDamage()
    {
        if (staminaUse>=damage+damageRange)
            return Random.Range(damage - damageRange, damage + damageRange + 1);
        else if (staminaUse>=damage-damageRange)
            return (int) Random.Range(damage - damageRange, staminaUse+1);
        return (int) staminaUse;
    }

    public void CoolDown()
    {
        isOnCooldown = true;
        // wait for some time
        isOnCooldown = false;
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

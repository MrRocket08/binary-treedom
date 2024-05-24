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
   
   public void Hit()
    {
        if (Input.GetMouseButton(0))
        {
            // animation of sword swinging
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), transform.rotation.eulerAngles.x);
            Debug.Log("Box cast");
            if (hits != null)
            {
                Debug.Log("Hit not null");
                foreach (Collider2D Col in hits)
                {
                    Debug.Log("One object hit");
                    if (Col.gameObject.CompareTag("Enemy"))
                    {
                        Col.gameObject.GetComponent<Enemy>().subtractHealth(Random.Range(damage - damageRange, damage + damageRange));
                        Debug.Log("Health subtracted from enemy");
                    }
                }
            }
        }

    }
   
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

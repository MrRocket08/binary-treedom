using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // fields
    public int health = 20;
    public int MAXHEALTH = 20;
    private float healthRegen = 1f;
    public HealthBar healthBar;
    public int stamina = 5;
    public int MAXSTAMINA = 5;
    private float staminaRegen = 1f;
    public StaminaBar staminaBar;
    private int speed;
    private int defense;
    public Item[] inventory = new Item[5];

    private SpriteRenderer sp;
    private Rigidbody2D rb;

    // class methods
    public void Attack() { }

    void Start()
    {
        sp = GameObject.Find("PlayerGFX").GetComponent<SpriteRenderer>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        health = MAXHEALTH;
        healthBar.SetMaxHealth(MAXHEALTH);

        stamina = MAXSTAMINA;
        staminaBar.SetMaxStamina(MAXSTAMINA);


    }

    void Update()
    {
        healthBar.SetHealth(health);
        staminaBar.SetStamina(stamina);

        staminaRegen -= Time.deltaTime;
        healthRegen -= Time.deltaTime;

        if (stamina <= MAXSTAMINA - 1 && staminaRegen <= 0)
        {
            stamina += 1;
            staminaRegen = 1;
        } else if (stamina == MAXSTAMINA) {
            staminaRegen = 1;
        }

        if (health <= MAXHEALTH - 1 && healthRegen <= 0)
        {
            health += 1;
            healthRegen = 1;
        } else if (health == MAXHEALTH) {
            healthRegen = 1;
        }
    }

    public void getHit(int damage, Vector2 knockback)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }

        rb.AddForce(knockback, ForceMode2D.Impulse);

        // add code here that makes the player flash white (using sp)
    }

    public void Die() { return; }

    // accessor methods
    public int getHealth() { return health; }
    public float getHealthRegen() { return healthRegen; }
    public int getStamina() { return stamina; }
    public float getStaminaRegen() { return staminaRegen; }
    public int getSpeed() { return speed; }
    public int getDefense() { return defense; }
    public Item[] getInventory() { return inventory; }

    // mutator methods
    public void setHealth(int _health) { health = _health; }
    public void setHealthRegen(int _healthRegen) { healthRegen = _healthRegen; }
    public void setStamina(int _stamina) { stamina = _stamina; }
    public void setStaminaRegen(float _staminaRegen) { staminaRegen = _staminaRegen; }
    public void setSpeed(int _speed) { speed = _speed; }
    public void setDefense(int _defense) { defense = _defense; }
    public void setInventory(int index, Item i) { inventory[index] = i; }
    public void addToInventory(Item i)
    {
        /* decide best index to add item to*/
        if (inventory[0] == null){setInventory(0, i);}
        else if (inventory[1] == null){setInventory(1, i);}
        else if (inventory[2] == null){setInventory(2, i);}
        else if (inventory[3] == null){setInventory(3, i);}
        else (inventory[4] == null){setInventory(4, i);}
    }
    public void removeItem(int index){inventory[index] = null;}
}

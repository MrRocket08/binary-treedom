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
    public float stamina = 5;
    public int MAXSTAMINA = 5;
    private float staminaRegen = 1f;
    public StaminaBar staminaBar;
    private int speed;
    private int defense;
    public Item[] inventory;

    // class methods
    public void Attack() { }

    void Start()
    {
        health = MAXHEALTH;
        healthBar.SetMaxHealth(MAXHEALTH);

        stamina = MAXSTAMINA;
        staminaBar.SetMaxStamina(MAXSTAMINA);
    }

    void Update()
    {
        //tested different speeds of stamina/health bar regen
        frameCounter++;
        if(frameCounter%1000==0)
        {
            frameCounter=0;
            canRegenHealth = true;

        }else
        {
            canRegenHealth = false;
        }

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

    // accessor methods
    public float getHealth() { return health; }
    public float getHealthRegen() { return healthRegen; }
    public float getStamina() { return stamina; }
    public float getStaminaRegen() { return staminaRegen; }
    public int getSpeed() { return speed; }
    public int getDefense() { return defense; }
    public Item[] getInventory() { return inventory; }

    // mutator methods
    public void setHealth(int _health) { health = _health; }
    public void setHealthRegen(int _healthRegen) { healthRegen = _healthRegen; }
    public void setStamina(float _stamina) { stamina = _stamina; }
    public void setStaminaRegen(float _staminaRegen) { staminaRegen = _staminaRegen; }
    public void setSpeed(int _speed) { speed = _speed; }
    public void setDefense(int _defense) { defense = _defense; }
    public void setInventory(int index, Item i) { inventory[index] = i; }
}

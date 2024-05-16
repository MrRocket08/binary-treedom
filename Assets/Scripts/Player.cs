using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // fields
    public float health;
    public int MAXHEALTH;
    private float healthRegen;
    public float stamina;
    public int MAXSTAMINA;
    private float staminaRegen;
    private int speed;
    private int defense;
    public Item[] inventory;
    public Weapon weapon;

    // class methods
    public void Attack()
    {

    }

    void Update()
    {
        if (health <= MAXHEALTH - healthRegen)
        {
            health += healthRegen;
        }

        if (stamina <= MAXSTAMINA - staminaRegen)
        {
            stamina += staminaRegen;
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
    public void setStamina(int _stamina) { stamina = _stamina; }
    public void setStaminaRegen(int _staminaRegen) { staminaRegen = _staminaRegen; }
    public void setSpeed(int _speed) { speed = _speed; }
    public void setDefense(int _defense) { defense = _defense; }
    public void setInventory(int index, Item i) { inventory[index] = i; }
}

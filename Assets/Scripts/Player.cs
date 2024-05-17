using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // fields
    public int health; //changed to int
    public int MAXHEALTH = 100; //can change this later but base for now
    private float healthRegen;
    public HealthBar healthBar;
    public int stamina;
    public int MAXSTAMINA = 100;
    private float staminaRegen;
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

        //testing method for health changes
        if(Input.GetKeyDown(KeyCode.Space)){
            health-=5;
            healthBar.SetHealth(health);
            stamina-=10;
            staminaBar.SetStamina(stamina);
        }
        
        /*if (health <= MAXHEALTH - healthRegen)
        {
            health += healthRegen;
        }*/

        /*if (stamina <= MAXSTAMINA - staminaRegen)
        {
            stamina += staminaRegen;
        }*/
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

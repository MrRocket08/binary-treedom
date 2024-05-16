using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // fields
    private int health;
    private float healthRegen;
    private int stamina;
    private float staminaRegen;
    private int speed;
    private int defense;
    public Item[] inventory;

    // class methods

    public void Attack() { }

    // accessor methods
    public int getHealth() { return health; }
    public float getHealthRegen() { return healthRegen; }
    public int getStamina() { return stamina; }
    public float getStaminaRegen() { return staminaRegen; }
    public int getSpeed() { return speed; }
    public int getDefense() { return defense; }
    public Item[] getInventory() { return inventory; }

    // mutator methods
}

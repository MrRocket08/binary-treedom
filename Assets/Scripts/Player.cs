using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // fields
    public int health = 20;
    public int MAXHEALTH = 20;
    private float healthRegen = 5f;
    public HealthBar healthBar;
    public int stamina = 8;
    public int MAXSTAMINA = 8;
    private float staminaRegen = 1f;
    public StaminaBar staminaBar;
    private int speed;
    private int defense;
    public Item[] inventory = new Item[5];
    private bool invincible;

    private SpriteRenderer sp;
    private Rigidbody2D rb;
    private WeaponManager wm;

    // class methods
    public void Attack() {
        if(stamina >= wm.getWeapon().getStaminaUse() && wm.getWeapon().getCooldown() <= 0)
        {
            wm.useWeapon();
        }
    }

    void Start()
    {
        sp = GameObject.Find("PlayerGFX").GetComponent<SpriteRenderer>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        wm = GameObject.Find("Weapon").GetComponent<WeaponManager>();

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

        if (Input.GetMouseButton(0) && wm.getWeapon() != null)
        {
            Attack();
        }

        if (stamina <= MAXSTAMINA - 1 && staminaRegen <= 0)
        {
            stamina += 1;
            staminaRegen = 1;
        }
        else if (stamina == MAXSTAMINA)
        {
            staminaRegen = 1;
        }

        if (health <= MAXHEALTH - 1 && healthRegen <= 0)
        {
            health += 1;
            healthRegen = 5f;
        }
        else if (health == MAXHEALTH)
        {
            healthRegen = 5f;
        }
    }

    public void getHit(int damage, Vector2 knockback)
    {
        if (!invincible)
        {
            health -= damage;

            StartCoroutine(DamageVisuals());

            if (health <= 0)
            {
                Die();
            } else
            {
                StartCoroutine(Invincibility());
            }
        }

        rb.AddForce(knockback, ForceMode2D.Impulse); //this currently just--doesn't work

        // add code here that makes the player flash white (using sp)
    }
    private IEnumerator DamageVisuals()
    {
        sp.color = Color.gray;

        yield return new WaitForSeconds(.1f);

        sp.color = Color.white;
    }

    // gives the player i-frames (they can't be hit again within this .25 second time period)
    public IEnumerator Invincibility()
    {
        invincible = true;

        yield return new WaitForSeconds(.25f);

        invincible = false;
    }

    public void Die() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        return; 
    }

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
    public bool addToInventory(Item i)
    {
        /* decide best index to add item to*/
        if (inventory[0] == null) { setInventory(0, i); return true; }
        else if (inventory[1] == null) { setInventory(1, i); return true; }
        else if (inventory[2] == null) { setInventory(2, i); return true; }
        else if (inventory[3] == null) { setInventory(3, i); return true; }
        else if (inventory[4] == null) { setInventory(4, i); return true; }
        else return false;
    }
    public void removeItem(int index) { inventory[index] = null; }
}

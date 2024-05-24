using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    // fields
    protected int damage;
    protected int damageRange;
    protected float useSpeed;
    protected float projSpeed;
    protected bool isPiercing;
    protected float cooldown;
    protected int staminaUse;

    public GameObject projectile;

    // class methods
    public void Hit()
    {
        Vector3 mousePositionScreen = Input.mousePosition;
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
        Vector2 shootDir = (mousePositionWorld - transform.position).normalized;

        GameObject _projectile = Instantiate(projectile, transform.position, Quaternion.identity);
        _projectile.transform.LookAt(mousePositionWorld);
        _projectile.GetComponent<Rigidbody2D>().AddForce(shootDir * projSpeed);
        _projectile.GetComponent<Projectile>().setFields(damage, isPiercing);

        cooldown = useSpeed;
    }
    public void Update()
    {
        cooldown -= Time.deltaTime;
    }

    public int HitDamage()
    {
        return Random.Range(damage - damageRange, damage + damageRange);
    }


    // accessor methods

    public string getName(){return name;}
    public int getDamage(){return damage;}
    public int getDamageRange(){return damageRange;}
    public float getUseSpeed(){return useSpeed;}
    public float getCooldown() { return cooldown; }
    public float getStaminaUse() { return staminaUse; }
    // mutator methods
}

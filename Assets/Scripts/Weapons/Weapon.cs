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

    public Player player;
    private Vector3 mousePositionScreen;
    private Vector3 mousePositionWorld;
    private Vector2 shootDir;

    // class methods
    public void Hit()
    {
        GameObject _projectile = Instantiate(projectile, transform.position, Quaternion.identity);
        _projectile.transform.right = shootDir;
        _projectile.GetComponent<Projectile>().setFields(damage, isPiercing);
        _projectile.GetComponent<Rigidbody2D>().AddForce(shootDir * projSpeed, ForceMode2D.Impulse);

        cooldown = useSpeed;

        player = GameObject.Find("Player").GetComponent<Player>();
        player.setStamina(player.getStamina() - staminaUse);
    }
    public void Update()
    {
        cooldown -= Time.deltaTime;

        mousePositionScreen = Input.mousePosition;
        mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
        shootDir = (mousePositionWorld - transform.position).normalized;

        transform.right = shootDir;
        transform.Rotate(new Vector3(0f, 0f, 45f));
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

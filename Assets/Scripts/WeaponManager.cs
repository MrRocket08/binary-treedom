using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon weapon;
    public GameObject interactable;

    private SpriteRenderer sp;
    private WeaponUI wu;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        wu = GameObject.Find("WeaponDisplay").GetComponent<WeaponUI>();
    }

    public void setWeapon(Weapon w)
    {
        weapon = w;

        sp.sprite = w.getSprite();

        wu.updateWeapon(w);
    }

    public void useWeapon()
    {
        weapon.Hit();
    }

    public Weapon getWeapon() { return weapon; }
}

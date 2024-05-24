using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon weapon;
    public GameObject interactable;

    private SpriteRenderer sp;

    private GameObject discarded;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public void setWeapon(Weapon w)
    {
        weapon = w;

        sp.sprite = w.getSprite();
    }

    public void useWeapon()
    {
        weapon.Hit();
    }

    public Weapon getWeapon() { return weapon; }
}

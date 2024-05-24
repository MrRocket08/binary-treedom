using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon weapon;
    public GameObject interactable;

    private SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = weapon.getSprite();
    }

    public void setWeapon(Weapon w)
    {
        GameObject discarded = Instantiate(interactable, transform.position, Quaternion.identity);
        discarded.GetComponent<Interactable>().setItemToGive(weapon);
        weapon = w;

        sp.sprite = weapon.getSprite();
    }

    public void useWeapon()
    {
        weapon.Hit();
    }
}

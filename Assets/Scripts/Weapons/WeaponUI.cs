using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Image img;

    public void updateWeapon(Weapon w)
    {
        img.sprite = w.getSprite();
    }
}

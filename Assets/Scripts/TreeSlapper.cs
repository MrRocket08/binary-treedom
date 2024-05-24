using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSlapper : Weapon
{
    private void Start()
    {
        damage = 5;
        damageRange = 2;
        useSpeed = 0.5f;
        projSpeed = 40f;
        isPiercing = false;
        cooldown = useSpeed;
        staminaUse = 1;
    }
}

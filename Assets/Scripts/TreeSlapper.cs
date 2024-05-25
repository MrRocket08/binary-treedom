using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSlapper : Weapon
{
    public TreeSlapper(Sprite _sprite, GameObject _projectile) : base()
    {
        damage = 3;
        damageRange = 1;
        useSpeed = 0.5f;
        projSpeed = 40f;
        isPiercing = false;
        cooldown = useSpeed;
        staminaUse = 2;
    }
    private void Start()
    {
        damage = 3;
        damageRange = 1;
        useSpeed = 0.5f;
        projSpeed = 40f;
        isPiercing = false;
        cooldown = useSpeed;
        staminaUse = 2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gladius : Weapon
{
    public Gladius(Sprite _sprite, GameObject _projectile) : base()
    {
        damage = 6;
        damageRange = 0;
        useSpeed = 1f;
        projSpeed = 50f;
        isPiercing = true;
        cooldown = useSpeed;
        staminaUse = 3;
    }
    private void Start()
    {
        damage = 6;
        damageRange = 0;
        useSpeed = 1f;
        projSpeed = 50f;
        isPiercing = true;
        cooldown = useSpeed;
        staminaUse = 3;
    }
}

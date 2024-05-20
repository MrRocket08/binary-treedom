using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSlapper : Weapon
{
    bool equipped = false;

    Transform currentTransform;

    
    public TreeSlapper(string nombre) : base(nombre, "TreeSlapper", 5, 3, 2, 20, 20){currentTransform = currentTransform;}

    // Update is called once per frame
    void Update()
    {
        if (equipped && Input.GetMouseButton(0)){
            // animation of sword swinging
            RaycastHit2D[] hits = Physics2D.BoxCastAll(currentTransform.position, new Vector2(1,1), currentTransform.rotation.eulerAngles.x, new Vector2(1,1), 2);
            if (hits != null){
                foreach (RaycastHit2D RH in hits){
                    if (RH.collider.gameObject.getType() == typeof(Enemy)){
                        Hit(RH.collider.gameObject.getType());
                    }
                }
            }
        }
    }

}

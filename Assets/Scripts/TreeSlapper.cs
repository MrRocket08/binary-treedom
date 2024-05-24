using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSlapper : Weapon
{

    public Transform currentTransform;
    public TreeSlapper(string nombre) : base(nombre, "TreeSlapper", 5, 3, 2, 20, 20) { currentTransform = transform; }

    // Update is called once per frame
    
    public void Update(){
        if (cooldown <=0){
            Hit();
            cooldown = 0.5f;
        }
        
        cooldown -= Time.deltaTime;

    }

}

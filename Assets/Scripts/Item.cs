using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    // fields
    protected bool inInventory;
    public Sprite sprite;

    // class methods
    protected void Use() { }

    // accessor methods
    protected bool isInInventory(){ return inInventory; }
    
    public Sprite getSprite() { return sprite;  }

    // mutator methods
    protected void AddToInventory(Player player){
        player.addToInventory(this);
        inInventory = true;
        Destroy(this);
    }


}

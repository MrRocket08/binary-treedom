using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    // fields
    private string name;
    private bool inInventory;

    // class methods
    protected void Use() { }

    // accessor methods
    protected bool isInInventory(){return inInventory;}

    // mutator methods
    protected void AddToInventory(Player player){
        player.addToInventory(this);
        inInventory = true;
        this.GameObject.Destroy();
    }
}

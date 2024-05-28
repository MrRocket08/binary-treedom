using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    public Player player;

    public GameObject gameobject;




    void OnCollisionEnter2D(Collision2D coll){
        if(coll.collider.tag == "Player"){
            player.health += 2;
            Debug.Log("2 health points added");
            Destroy(this.gameObject);
        }
    }
}

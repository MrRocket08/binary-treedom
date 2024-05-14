using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal"); // value btwn -1 and 1 from keyboard
       
    }

    void FixedUpdate(){
        // move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    }
}

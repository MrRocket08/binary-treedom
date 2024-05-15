using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 40f;
    Vector2 movement;


    // Update is called once per frame
    void Update()
    {
        // input
        movement.x = Input.GetAxisRaw("Horizontal"); // value in {-1, 0, 1} from keyboard
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // movement
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}

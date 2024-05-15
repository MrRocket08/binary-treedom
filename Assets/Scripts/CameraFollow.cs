using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 5f;
    public Transform target;

    public float maxLeft;
    public float maxRight;
    public float maxUp;
    public float maxDown;

    private Vector3 newPos;
    private Vector3 cursorPos;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //cursorPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x - target.position.x, Input.mousePosition.y - target.position.y, -10f));

        //cursorPos.x *= -(float)0.4;
        //cursorPos.y *= -(float)0.4;

        newPos = new Vector3(target.position.x, target.position.y, -10f);

        // clamp the camera to the bounds
        newPos.x = Mathf.Clamp(newPos.x, maxLeft, maxRight);
        newPos.y = Mathf.Clamp(newPos.y, maxDown, maxUp);
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
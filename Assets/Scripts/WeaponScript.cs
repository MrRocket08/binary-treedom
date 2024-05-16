using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Vector3 mousePositionScreen;
    private Vector3 mousePositionWorld;
    private Vector2 pointDirection;
    void Update()
    {

        mousePositionScreen = Input.mousePosition;
        mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);

        pointDirection = (mousePositionWorld - transform.position).normalized;
    }
}

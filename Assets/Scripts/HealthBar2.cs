using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
{    public Slider slider;
    public int x;

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}

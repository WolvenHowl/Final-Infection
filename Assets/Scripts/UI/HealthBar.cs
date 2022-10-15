using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Healthslider;
    
    private void Start() 
    {
        Healthslider = gameObject.GetComponent<Slider>();
    }

    public void SetMaxHealth(int health)
    {
        Healthslider.maxValue = health;
        Healthslider.value = health;
    }

    public void SetHealth(int health)
    {
        Healthslider.value = health;
    }
}

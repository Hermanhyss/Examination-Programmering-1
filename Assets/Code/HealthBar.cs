using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image Fill;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider .value = health;

        Fill.color = gradient.Evaluate(0.5f);
    }

    public void SetHealth (int health)
    {
        slider .value = health;

        Fill.color = gradient.Evaluate(slider.normalizedValue); 
    }
}

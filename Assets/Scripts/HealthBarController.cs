using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient colourChange;
    [SerializeField] private Image fill;

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = colourChange.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }
}

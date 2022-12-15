using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthSlider;
    public Gradient HealthGradient;
    public Image ColorFill;

    public void SetMaxHealth(float maxhealth)
    {
        HealthSlider.maxValue = maxhealth;
        HealthSlider.value = maxhealth;

        ColorFill.color = HealthGradient.Evaluate(1f);
    }

    public void SetCurrentHealth(float currenthealth)
    {
        HealthSlider.value = currenthealth;

        ColorFill.color = HealthGradient.Evaluate(HealthSlider.normalizedValue);
    }

    
}

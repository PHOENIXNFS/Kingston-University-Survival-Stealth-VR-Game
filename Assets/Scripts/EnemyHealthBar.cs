using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider EnemyHealthSlider;


    public void SetMaxHealth(float maxhealth)
    {
        EnemyHealthSlider.maxValue = maxhealth;
        EnemyHealthSlider.value = maxhealth;

    }

    public void SetCurrentHealth(float currenthealth)
    {
        EnemyHealthSlider.value = currenthealth;
    }
}

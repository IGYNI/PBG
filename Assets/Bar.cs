using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;



    
    public void SetHealt(float health)
    {
        slider.value = health;

        Debug.Log(health);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    


}

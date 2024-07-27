using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class XpBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxCurrentXp(int MAX_XP)
    {
        slider.maxValue = MAX_XP;
        slider.value = MAX_XP;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetXp(int XP)
    {
        slider.value = XP;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

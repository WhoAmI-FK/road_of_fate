using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthText : MonoBehaviour
{
    TMP_Text text;
    public static int curHealth;
    public static int maxHealth;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = curHealth.ToString() + "/" + maxHealth.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XpText : MonoBehaviour
{
    TMP_Text text;
    public static int currentExp;
    public static int requiredExp;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = currentExp.ToString() + "/" + requiredExp.ToString();
    }
}

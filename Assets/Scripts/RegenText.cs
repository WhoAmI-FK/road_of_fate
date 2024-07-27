using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegenText : MonoBehaviour
{
    TMP_Text text;
    public static int HPRegDisplay;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "+" + HPRegDisplay;
    }
}

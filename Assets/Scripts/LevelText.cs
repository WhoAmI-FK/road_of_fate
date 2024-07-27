using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelText : MonoBehaviour
{
    TMP_Text text;
    public static int level;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = "Level " + level;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    [SerializeField]
    private int hpRegen;

    public GameObject objToDisplay;

    public float nextRegen = 0;
    public float stopDisplay = 0;

    void Start()
    {
        RegenText.HPRegDisplay = hpRegen;
    }

    public void incRegen(int regen)
    {
        hpRegen += regen;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextRegen)
        {
            if (hpRegen > 0)
            {
                FindObjectOfType<Player>().DrinkPotion(hpRegen);
                objToDisplay.SetActive(true);
            }
            nextRegen = Time.time + 5f;
            stopDisplay = Time.time+3f;
        }
        if(Time.time>=stopDisplay)
        {
            objToDisplay.SetActive(false);
        }
        RegenText.HPRegDisplay = hpRegen;
    }
}

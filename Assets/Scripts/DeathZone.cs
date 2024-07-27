using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public static bool isDead = false;

    public static Collider2D localcollider;
    void Delay()
    {
        Debug.Log("You are Dead!");
        isDead = false;
        localcollider.transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        localcollider = col;
        if (col.transform.CompareTag("Player"))
        {
            isDead = true;
            Invoke("Delay", 2.5f);
        }
    }
}
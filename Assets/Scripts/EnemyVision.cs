using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.CompareTag("Player"))
        {
            EnemyBehavior._speed = 0.7f;
        }
    }
}

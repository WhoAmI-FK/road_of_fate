using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaKill : MonoBehaviour
{
    public Player playerRef;

    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Objects do not collide");
        if(col.gameObject.CompareTag("Player"))
        {
            playerRef.TakeDamage(playerRef.maxHealth + 1);
        }
    }
}

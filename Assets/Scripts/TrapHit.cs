using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHit : MonoBehaviour
{
    public Animator anim;
    public Player player;
    private bool playerInTheArea = false;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(15);
        }
    }

    void Update()
    {
        var current_animation = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        // Debug.Log("ANIM: " + current_animation);
        if (current_animation == "TrapOut")
        {
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        else
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}

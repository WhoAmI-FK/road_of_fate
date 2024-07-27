using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseV1 : MonoBehaviour
{
    public static float speed = 1f;
    private Transform target;
    public Animator animator;
    public Player player;
    public SpriteRenderer sr;
    private Transform current;
    private float xLegacy, xCurrent;
    private bool currentFlip;

    public void Start()
    {
        xLegacy = xCurrent = transform.position.x;
    }

    private void Update()
    {
        if (target != null)
        {
            if(animator.GetBool("isDead") == true)
            {
                speed = 0;
            }
            float step = speed*Time.deltaTime*0.5f;
            animator.SetFloat("Speed", speed);
            Debug.Log("Current speed is " + speed);
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            xCurrent = transform.position.x;
        }
        if (xLegacy > xCurrent)
        {
            sr.flipX = true;
            currentFlip = true;
        }
        else if (xLegacy == xCurrent)
        {
            sr.flipX = currentFlip;
        }
        else
        {
            sr.flipX = false;
            currentFlip = false;
        }
        xLegacy = xCurrent;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered the area");
        
        if(other.gameObject.tag == "Player")
        {
            speed = 1f;
            animator.SetFloat("Speed", speed);
            target = other.transform;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "EnvColliders")
        {
         //   speed = 0f;
         //   animator.SetFloat("Speed", speed);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player exit the area");
        if (other.gameObject.tag == "Player")
        {
            speed = 0f;
            animator.SetFloat("Speed", speed);
            target = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseV1RangeUnit : MonoBehaviour
{
    public static float speed = 1f;
    private Transform target;
    public Animator animator;
    public Player player;
    public SpriteRenderer sr;
    private Transform current;
    private float xLegacy, xCurrent;
    private bool currentFlip;

    void Start()
    {
        xLegacy = xCurrent = transform.position.x;
    }

    void Update()
    {
        if (target != null)
        {
            if (animator.GetBool("isDead") == true)
            {
                speed = 0;
                animator.SetFloat("Speed", speed);
            }
            //Debug.Log("Distance!: " + Vector3.Distance(transform.position, target.position));
            else if (Vector3.Distance(transform.position, target.position) >= 1) {
                speed = 1f;
                float step = speed * Time.deltaTime * 0.5f;
                animator.SetFloat("Speed", speed);
//                var _targetPos = Vector2.MoveTowards(transform.position, target.position, step);
 //               gameObject.GetComponent<Rigidbody2D>().MovePosition(_targetPos);
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
                xCurrent = transform.position.x;
            }else
            {
                speed = 0;
                animator.SetFloat("Speed", speed);
            }
        }
            if(xLegacy > xCurrent)
            {
                sr.flipX = true;
                currentFlip = true;
            }else if(xLegacy==xCurrent)
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Enemy collides");

        if (other.gameObject.tag == "EnvColliders")
        {
            //speed = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered the area");
        if(other.gameObject.tag == "Player")
        {
            speed = 1f;
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player exit the area");
        if(other.gameObject.tag == "Player")
        {
            speed = 0f;
            target = null;
        }
    }

}

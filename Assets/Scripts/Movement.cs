using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public Vector2 movePosition;
    private SpriteRenderer sr;
    private Animator animator;
    public float step;

    void Start()
    {
        step = 0f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (DeathZone.isDead == true)
        {
            animator.SetBool("isDead", true);
            speed = 0f;
        }
        else
        {
            animator.SetBool("isDead", false);
            speed = 1.5f;
        }
        animator.SetBool("Attack", false);
        animator.SetBool("powerfulAttack", false);
        animator.SetBool("Jump", false);
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var valx = Mathf.Abs(moveInput.x);
        var valy = Mathf.Abs(moveInput.y);
        if (valx == moveInput.y && valx != 0)
        {
            animator.SetFloat("Speed", 1f);
        }
        else if(valy == moveInput.x && valy != 0)
        {
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(moveInput.x + moveInput.y));
        }
        if(animator.GetFloat("Speed") != 0)
        {

            if (Time.time >= step)
            {
                step = Time.time + 0.25f;
                FindObjectOfType<AudioManager>().Play("PlayerStep");
            }
        }
        movePosition = moveInput * speed;
        if (movePosition.x < 0)
        {
            sr.flipX = true;
        }
        if (movePosition.x > 0)
        {
            sr.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Attack", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("powerfulAttack", true);
        }
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            animator.SetBool("Jump", true);
            movePosition.y = movePosition.y + 10;
        }
        rb.velocity = new Vector2(moveInput.x, moveInput.y);

    }
}
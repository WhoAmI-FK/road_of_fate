using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator animator;
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    public Vector2 movePosition;
    

    private enum MovementState { idle, running, jumping, falling }

    public static bool newScene = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        if (newScene)
        {
            PlayerPrefs.SetFloat("xPos", -10.35001f);
            PlayerPrefs.SetFloat("yPos", -1.16f);
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));
        }
        else
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));
        }
        newScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        //jumping has a higher priority
        //while the player is in the air they don't want to see the running or idle animation
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "checkpoint")
        {
            PlayerPrefs.SetFloat("xPos", transform.position.x);
            PlayerPrefs.SetFloat("yPos", transform.position.y);
        }
        if(other.tag == "Finish")
        {
            SceneLoader.LoadScene(3);
        }
    }

    // the player will be able to jump only if they're standing on some ground
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}

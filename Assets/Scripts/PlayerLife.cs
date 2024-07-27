using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Vector3 respawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        //change this to the top down scene once both scenes will be present in the project
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Fall Detector
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fallDetector")
        {
            anim.SetTrigger("death");
        }
    }

}

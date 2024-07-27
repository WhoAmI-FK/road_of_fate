using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType { FlyingEye, Mushroom, Skeleton};
    public EnemyType _enemyType;
    public Animator animator;
    [SerializeField]
    private LevelSystem ls;
    [SerializeField]
    private int EXP;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        switch(_enemyType)
        {
            case EnemyType.FlyingEye:
                FindObjectOfType<AudioManager>().Play("FlyingEyeHurt");
                break;
            case EnemyType.Mushroom:
                FindObjectOfType<AudioManager>().Play("MushroomHurt");
                break;
            case EnemyType.Skeleton:
                FindObjectOfType<AudioManager>().Play("SkeletonHurt");
                break;
        }

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        animator.SetBool("isDead", true);
        // Die Animation
        ls.GainExperience(EXP);
        // Disable the enemy
    //    EnemyBehavior._speed = 0f;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Invoke("Destr", 1f);
        // before starting animation it should have no physics
    }

    void Destr()
    {
        Destroy(gameObject);
    }
}

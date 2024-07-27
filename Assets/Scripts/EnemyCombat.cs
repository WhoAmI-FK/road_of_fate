using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public int EnemyAttackDamage = 5;
    public Animator enemyAnimator;
    public Transform enemyAttackPoint;
    public Player _player;
    //public float attackRange = 0.5f;
    public LayerMask PlayerLayer;
    int currentPlayerHealth;
    public Rigidbody2D rb;
    public int playerMaxHealth = 200;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    bool enemyAttack;
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            EnemyChaseV1.speed = 0;
            enemyAttack = true;
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            EnemyChaseV1.speed = 1;
            enemyAttack = false;
        }
    }


    void Start()
    {
        currentPlayerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAttack && !enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            enemyAnimator.SetTrigger("Attack");
        }
        if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            //    enemyAttack = true;
            if (enemyAttack)
            {
                if (Time.time >= nextAttackTime)
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    void Attack()
    {
        // Animation is already played
        _player.GetComponent<Player>().TakeDamage(EnemyAttackDamage);
        FindObjectOfType<AudioManager>().Play("EyeBite");
    }

    /*  void OnDrawGizmosSelected()
      {
          if (attackPoint == null)
              return;

          Gizmos.DrawWireSphere(attackPoint.position, attackRange);
      }
    */

}

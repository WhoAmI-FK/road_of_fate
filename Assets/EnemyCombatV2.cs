using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatV2 : MonoBehaviour
{
    [SerializeField]
    private int enemyAttackDamage;

    [SerializeField]
    private int enemyStrongAttackDamage;

    public Animator enemyAnimator;
    public Transform enemyAttackPoint;
    public Player player;
    public LayerMask PlayerLayer;
    int currentPlayerHealth;
    public Rigidbody2D rb;
    public int playerMaxHealth = 200;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    float strongAttackTime = 0f;
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
        if(col.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            EnemyChaseV1.speed = 1;
            enemyAttack = false;
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  if(enemyAttack && /*!enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("StrongAttack"))
        {
            enemyAnimator.SetTrigger("Attack");
        }
      */
      //  if(enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
       // {
            if(enemyAttack)
            {
                if(Time.time >= nextAttackTime)
                {
                    enemyAnimator.SetTrigger("Attack");
                    Attack();
                    nextAttackTime = Time.time + 2f / attackRate;
                }
            }
        //}
        if (enemyAttack)
        {
            if (Time.time >= strongAttackTime)
            {
      
                enemyAnimator.SetTrigger("StrongAttack");

                StrongAttack();
                strongAttackTime = Time.time + 2f;
            }
        }
       

    }

    void Attack()
    {
        FindObjectOfType<AudioManager>().Play("SkeletonAttack");
        player.TakeDamage(enemyAttackDamage);
    }
    void StrongAttack()
    {
        player.TakeDamage(enemyStrongAttackDamage);
    }
}

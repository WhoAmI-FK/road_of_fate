using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public int attackDamage = 20;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    int currentHealth;
    public int maxHealth = 100;
    public float attackRate = 4f;
    float nextAttackTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        DamageText.damage = attackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                Attack();
                FindObjectOfType<AudioManager>().Play("PlayerAttack");
                nextAttackTime = Time.time + (1f / attackRate);
                Debug.Log("nextAttackTimeVal:" + nextAttackTime);
                Debug.Log("Time.time: " + Time.time);

            }
        }
    }

    void Attack()
    {
        // Animation is already played
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("LOOK HERE BRO:");
            if (!(enemy.GetType() == typeof(CircleCollider2D)))
            {
                Debug.Log("We hit" + enemy.name);
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            if(enemy.gameObject.CompareTag("Bullet"))
            {
                Debug.Log("WTFFFF");
                Destroy(enemy.gameObject);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) 
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void IncDamage(int extraDamage)
    {
        attackDamage += extraDamage;
        DamageText.damage = attackDamage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public int maxHealth = 200;
    int currentHealth;
    private PlayerCombat pc;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        HealthText.curHealth = currentHealth;
        HealthText.maxHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        pc = GetComponent<PlayerCombat>();
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);
        HealthText.curHealth = currentHealth;
        HealthText.maxHealth = maxHealth;
        if (currentHealth < 0)
        {
            Death();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("TakeHit");
    }


    void Death()
    {
        gameObject.GetComponent<Movement>().enabled = false;
        gameObject.GetComponent<PlayerCombat>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        animator.SetBool("isDead", true);
        currentHealth = 0;

        FindObjectOfType<GameManager>().EndGame();
        
    }

    public void DrinkPotion(int HP)
    {
        currentHealth = currentHealth + HP > maxHealth ? maxHealth : currentHealth+HP;
    }

    public void IncDamage(int dmg)
    {
        pc.IncDamage(dmg);
    }

    public void IncMaxHealth(int extraHP)
    {
        int tmp = maxHealth;
        maxHealth += extraHP;
        currentHealth += (maxHealth - tmp);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}

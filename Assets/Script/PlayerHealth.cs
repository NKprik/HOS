using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public HealthBar healthBar;
    public ManaBar manaBar;

    public int maxHealth = 100;
    int currentHealth;

    public int maxMana = 100;
    int currentMana;

    private WaitForSeconds regenTick = new WaitForSeconds(.1f);
    private Coroutine regen;

    public float delay = 4;
       void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SpendMana(20);
        }
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        StartCoroutine(DamageAnimation());

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    

    public void SpendMana(int manaCost)
    {
        if(currentMana - manaCost >=0)
        {
            currentMana -= manaCost;
            manaBar.SetMana(currentMana);

            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenMana());
        }
        else
        {
            Debug.Log("Not enough mana");
        }

        
    }

    void Die()
    {
        animator.SetBool("IsDead", true);

        GetComponent<Rigidbody2D>().simulated = false;

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        StartCoroutine(LoadLevelAfterDelay(delay));
        //SceneManager.LoadScene("Mechanic");
    }

    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator RegenMana()
    {
        yield return new WaitForSeconds(2);

        while(currentMana < maxMana)
        {
            currentMana += maxMana / 100;
            manaBar.SetMana(currentMana);
            yield return regenTick;
        }
        regen = null;
    }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Mechanic");
    }
}

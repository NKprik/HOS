using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletPrefeb;

    public Transform attackPoint;
    public Transform firePoint;

    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 20;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                RangeAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.gameObject.tag == "Boss")
            {
                enemy.gameObject.GetComponent<BossHealth>().TakeDamage(attackDamage);
                //print("111");
            }
            else
            {
                enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                //print("222");
            }
            

        }
    }

    void RangeAttack()
    {
        animator.SetTrigger("RangeAttack");

        Instantiate(bulletPrefeb, firePoint.position, firePoint.rotation);
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

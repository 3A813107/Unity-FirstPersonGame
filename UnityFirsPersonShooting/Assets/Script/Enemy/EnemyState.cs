using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField] protected int Health;
    public int maxHealth;
    [SerializeField] protected bool isDead;

    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private bool canAttack = true;

    private void Start()
    {
        Health = maxHealth;
        isDead = false;
        canAttack = true;
    }

    public void DealDamage()
    {

    }

    public void CheckHealth()
    {
        if(Health <= 0)
        {
            Health = 0;
            Die();
        }
        if(Health >= maxHealth)
        {
            Health = maxHealth;
        }
    }
    public void SetHealth(int healthToSetTo)
    {
        Health = healthToSetTo;
        CheckHealth();
    }

    public void TackDamge(int damage)
    {
        int healthAfterDamage = Health - damage;
        SetHealth(healthAfterDamage);
    }
    public void Heal(int heal)
    {
        int healthAfterheal = Health + heal;
        SetHealth(healthAfterheal);
    }
    public void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}


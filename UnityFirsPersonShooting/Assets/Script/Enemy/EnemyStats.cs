using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int Health;
    public int maxHealth;
    [SerializeField] protected bool isDead;

    private EnemyController controller;

    [SerializeField] private int damage;
    public float attackSpeed;

    private void Start()
    {
        Health = maxHealth;
        isDead = false;
        controller = GetComponent<EnemyController>();
    }

    public void DealDamage(PlayerStats statsToDamege)
    {
        statsToDamege.DamegCheaak(damage);
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
        if(controller.boomIv[0]!=null)
        {
            GameManager.instance.isboomTaking = false;
            Instantiate(controller.boomIv[0].PickUpPrefab,controller.BoomDrop.position,controller.BoomDrop.rotation);
            GameManager.instance.currentBoomPos = transform.position;
        }
        Destroy(gameObject);
    }
}


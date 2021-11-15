using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int Health;
    public int maxHealth;
    public int Shield;
    public int maxShield;

    [SerializeField] protected bool isDead;

    private EnemyController controller;

    [SerializeField] private int damage;
    public float attackSpeed;
    private EnemyImfo enemyImfo;

    private void Start()
    {
        enemyImfo=GetComponent<EnemyObject>().enemyImfo as EnemyImfo;
        EnemySet();
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

    public void DamageHealth(int damage)
    {
        int healthAfterDamage = Health - damage;
        SetHealth(healthAfterDamage);
    }

    public void DamageShield(int damage)
    {
        int realShiledDamage=(int)(damage*0.8);//護甲減傷
        if(realShiledDamage==0)
            realShiledDamage=1;
        Shield-=realShiledDamage;
    }

    public void DamageCheak(int damage)
    {
        if(Shield > 0)
        {
            DamageShield(damage);
        }
        else if(Shield <= 0)
        {
            DamageHealth(damage);
        }
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

    private void EnemySet()
    {
        maxHealth=enemyImfo.Hp;
        maxShield=enemyImfo.Shiled;
        damage = enemyImfo.Damage;
        attackSpeed=enemyImfo.AttackSpeed;
        Health = maxHealth;
        Shield=maxShield;
        isDead = false;
    }
}


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
    [SerializeField] private Transform player;
    private PlayerStats playerStats;

    public GameObject damageText;
    public Transform damageTextPos;

    public float ShieldPower = 0.8f;

    private void Start()
    {
        enemyImfo=GetComponent<EnemyObject>().enemyImfo as EnemyImfo;
        EnemySet();
        playerStats=player.GetComponent<PlayerStats>();
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
        DamageTextSet(damage,Color.red);
        SetHealth(healthAfterDamage);
    }

    public void DamageShield(int damage)
    {
        if(Shield != 0)
            DamageTextSet(damage,new Color(0.2588235f,0.9921569f,0.9869152f));
        Shield-=damage;
        if(Shield < 0)
            Shield = 0;
    }

    public void DamageCheak(int damage)
    {
        int finalDamage;
        if(Shield > 0)
        {
           finalDamage =  (int) (damage * ShieldPower);
           if(finalDamage==0)
            finalDamage = 1;
        }
        else
        {
            finalDamage = damage;
        }
        int realDamage = finalDamage - Shield;
        if(realDamage <= 0)
        {
            DamageShield(finalDamage);
        }
        else if(realDamage > 0)
        {
            DamageHealth(realDamage);
            DamageShield(Shield);
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
        playerStats.GetMoney(100);
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

    private void DamageTextSet(int damage,Color color)
    {
        DamageText damageTextUI = Instantiate(damageText,damageTextPos.position,Quaternion.identity).GetComponent<DamageText>();
        damageTextUI.SetDamageText(damage,color);
    }
}


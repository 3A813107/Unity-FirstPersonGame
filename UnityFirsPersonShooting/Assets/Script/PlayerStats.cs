using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] protected int Health;
    public int maxHealth;
    [SerializeField] protected bool isDead;
    [SerializeField]private int Shield;
    public int MaxShield;
    public float ShieldRecoveryCoolDown;
    public float ShieldRecoveryRate=1;
    private float ShieldCount;

    private float Shieldval;

    public PlayerHUD hud;

    private void Start()
    {
        Shield = MaxShield;
        Health = maxHealth;
        isDead = false;
        hud=GetComponent<PlayerHUD>();
    }

    private void Update()
    {               
        ShieldRecoveryCheak();
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
        hud.UpdateHealth(Health,maxHealth);
    }
    public void SetHealth(int healthToSetTo)
    {
        Health = healthToSetTo;
        CheckHealth();
    }

/////////////////////////////////////////////////////////
    public void DamageShield(int damage)
    {
        Shield -= damage;
        Shieldval = Shield;
        ShieldCount = 0;
    }

    private void ShieldRecoveryCheak()
    {  
        hud.UpdateShield(Shield,MaxShield);
        if(Shield < MaxShield)
        {            
            ShieldRecovery();
        }
    }
    private void ShieldRecovery()
    {
        if(ShieldCount >= ShieldRecoveryCoolDown)
            {
                Shieldval += Time.deltaTime * ShieldRecoveryRate;
                Shield = Mathf.RoundToInt(Shieldval);
            }
        else
        {
            ShieldCount += Time.deltaTime;
        }
    }
////////////////////////////////////////////////////////////
    public void DamegCheaak(int damage)
    {  
        int realDamage = damage - Shield;
        if(realDamage <= 0)
        {
            DamageShield(damage);
        }
        else if(realDamage > 0)
        {
            DamageShield(Shield);
            DamageHealth(realDamage);
        }
    }
    public void DamageHealth(int damage)
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
    }

}

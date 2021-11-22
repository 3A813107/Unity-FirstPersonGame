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

    public float ShieldPower=0.8f;
    public float ShieldRecoveryCoolDown;
    public float ShieldRecoveryRate=1;
    private float ShieldCount;

    private float Shieldval;//轉整數的代數

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
        if(Shield < 0)
            Shield=0;
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

    public void GetMoney(int Num)
    {
        GameManager.instance.PlayerMoney+=Num;
        hud.UpdateMoneyUI(GameManager.instance.PlayerMoney);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

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
    public CharacterController controller;

    public Image Dmgshiled;
    public Image Dmghealth;
    public float ImgTime;

    public float targetAplpha = 0.4f;
    public float ImgFadaRate;
    public GameObject gameHud;
    public Camera cam;
    public Transform respawnPoint;
    [SerializeField]private UIManager ui;
    public ReSpawnUI reui;
    public float respawnTimeCounter;

    private void Start()
    {
        Shield = MaxShield;
        Shieldval = Shield;
        Health = maxHealth;
        isDead = false;
        hud=GetComponent<PlayerHUD>();
        controller= GetComponent<CharacterController>();
        ui=GetComponent<UIManager>();
        respawnTimeCounter = GameManager.instance.respawnTime;
    }

    private void Update()
    {               
        ShieldRecoveryCheak();
        if(isDead)
            RespawnCheak();  
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

    public void CheackMaxHealth(int health)
    {
        Health+=health;
        hud.UpdateHealth(Health,maxHealth);
    }

/////////////////////////////////////////////////////////
    public void DamageShield(int damage)
    {
        Shield -= damage;
        if(Shield < 0)
            Shield=0;
        Shieldval = Shield;
        ShieldCount = 0;
        if(Shield!=0)
        {
            StartCoroutine(ShieldFlash());
            CameraShaker.Instance.ShakeOnce(2f,2f,0.5f,0.5f);
        }

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
        StartCoroutine(HealthFlash());
        CameraShaker.Instance.ShakeOnce(2f,2f,0.5f,0.5f);
    }
    public void Heal(int heal)
    {
        int healthAfterheal = Health + heal;
        SetHealth(healthAfterheal);
    }

    public void Die()
    {
        isDead = true;
        GameManager.instance.PlayerDie = isDead;
        controller.enabled = false;
        gameHud.SetActive(false);
        cam.cullingMask = ~(1 << 3);
        ui.SetActiveRespawn(true);
    }
    
    public void GetMoney(int Num)
    {
        GameManager.instance.PlayerMoney+=Num;
        hud.UpdateMoneyUI(GameManager.instance.PlayerMoney);
    }

    IEnumerator ShieldFlash()
    {    
        Dmgshiled.enabled = true;
        yield return new WaitForSeconds(ImgTime);
        Dmgshiled.enabled = false;
    }
    IEnumerator HealthFlash()
    {
        Dmghealth.enabled = true;
        yield return new WaitForSeconds(ImgTime);
        Dmghealth.enabled = false;
    }

    public void Respawn()
    {
        Health = maxHealth;
        Shield = MaxShield;
        hud.UpdateHealth(Health,maxHealth);
        hud.UpdateShield(Shield,MaxShield);
        isDead = false;
        GameManager.instance.PlayerDie = isDead;
        controller.enabled = true;
        gameHud.SetActive(true);
        cam.cullingMask = -1;
        transform.position = respawnPoint.transform.position;
        Physics.SyncTransforms();
        ui.SetActiveRespawn(false);
        respawnTimeCounter = GameManager.instance.respawnTime;
    }

    private void RespawnCheak()
    {
        if(respawnTimeCounter > 0)
        {
            respawnTimeCounter -= Time.deltaTime;
            reui.UpdateRespawnTimer(respawnTimeCounter);
        }
        else
        {
            Respawn();
        }
    }
}

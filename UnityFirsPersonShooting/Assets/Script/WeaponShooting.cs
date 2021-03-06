using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    private float lastShootTime=0;
    [SerializeField]private bool canShoot=true;
    public bool canShoot_swap;
    public bool canReload;
    /////////////////////////////////////////////////////
    [SerializeField]private int primaryCurrentAmmo;
    [SerializeField]private int primaryCurrentTotalAmmo;
    //////////////////////////////////////////////////////
    [SerializeField]private int secondprimaryCurrentAmmo;
    [SerializeField]private int secondprimaryCurrentTotalAmmo;
    ////////////////////////////////////////////////////////////
    [SerializeField]private int secondaryCurrentAmmo;
    [SerializeField]private int secondaryCurrentTotalAmmo;
    /////////////////////////////////////////////////////////////
    
    [SerializeField]private GameObject BloodPS = null;
    
    private Camera cam;
    private Inventory inventory;
    private EquipmentManager manager;
    private PlayerHUD hud;
    private GunRecoil recoil;
    private Animator anim;

    public GameObject Bullet;

    public AudioSource aud;
    public AudioClip hit_snd;

    private void Start()
    {
        canShoot_swap=false;
        canReload=true;
        hud=GetComponent<PlayerHUD>();
        cam=GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        manager = GetComponent<EquipmentManager>();
        anim = GetComponentInChildren<Animator>();
        recoil = GetComponentInChildren<GunRecoil>();
        aud = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.LeftShift) && !GameManager.isPause && !GameManager.instance.PlayerDie)
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R) && !GameManager.isPause && !GameManager.instance.PlayerDie)
        {
            Reload(manager.currentEquippedWeapon);
        }
    }

    private void RaycastShoot(Weapon currentWeapon)
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2,Screen.height / 2));

        RaycastHit hit;

        float currentWeaponRange = currentWeapon.range;

        if(Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
            GameObject tempBullet = Instantiate(Bullet,manager.currentWeaponFlash.position,Quaternion.LookRotation(transform.forward));
            tempBullet.GetComponent<BulletMove>().hitPoint=hit.point;
            if(hit.transform.tag == "Enemy")
            {
                aud.PlayOneShot(hit_snd,0.5f);
                hit.transform.GetComponent<EnemyStats>().DamageCheak(currentWeapon.damage);
                Instantiate(BloodPS, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else
            {
                Instantiate(currentWeapon.impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        Instantiate(currentWeapon.muzzleFlashParticles,manager.currentWeaponFlash);
    }

    private void Shoot()
    {
        ChackCanShoot(manager.currentEquippedWeapon);

        if(canShoot && canShoot_swap && canReload)
        {
            Weapon currentWeapon = inventory.GetItem(manager.currentEquippedWeapon);

            if(Time.time > lastShootTime + currentWeapon.fireRate)
            {
                lastShootTime = Time.time;
                UseAmmo((int)currentWeapon.weaponStyle,1,0);
                recoil.RecoilFire();
                RaycastShoot(currentWeapon);
                aud.PlayOneShot(currentWeapon.shot_sound,0.06f);
            }
        }    

    }
    
    public void InitAmmo(int style,Weapon weapon)
    {
        if(style == 0)
        {
            primaryCurrentAmmo = weapon.magazinSize;
            primaryCurrentTotalAmmo = weapon.TotalAmmo;
        }
        if(style == 1)
        {
            secondprimaryCurrentAmmo = weapon.magazinSize;
            secondprimaryCurrentTotalAmmo = weapon.TotalAmmo;
        }
        if(style == 2)
        {
            secondaryCurrentAmmo = weapon.magazinSize;
            secondaryCurrentTotalAmmo = weapon.TotalAmmo;
        }        
    }

    public void UseAmmo(int style,int currentAmmoUsed,int currentTotalAmmoUsed)

    {
        if(style == 0)
        {
            if(primaryCurrentAmmo <= 0)
            {
                ChackCanShoot(manager.currentEquippedWeapon);
            }

            else
            {
                primaryCurrentAmmo -= currentAmmoUsed;
                primaryCurrentTotalAmmo -= currentTotalAmmoUsed;
                hud.UpdateWeaponAmmoUI(primaryCurrentAmmo,primaryCurrentTotalAmmo);
            }   

        }
        if(style == 1)
        {
            if(secondprimaryCurrentAmmo <= 0)
            {
                ChackCanShoot(manager.currentEquippedWeapon);
            }
            else
            {         
                secondprimaryCurrentAmmo -= currentAmmoUsed;
                secondprimaryCurrentTotalAmmo -= currentTotalAmmoUsed;
                hud.UpdateWeaponAmmoUI(secondprimaryCurrentAmmo,secondprimaryCurrentTotalAmmo);                
            }
        }
        if(style == 2)
        {
            if(secondaryCurrentAmmo <= 0)
            {
                ChackCanShoot(manager.currentEquippedWeapon);
            }               
            else
            {
                secondaryCurrentAmmo -= currentAmmoUsed;
                secondaryCurrentTotalAmmo -= currentTotalAmmoUsed;
                hud.UpdateWeaponAmmoUI(secondaryCurrentAmmo,secondaryCurrentTotalAmmo,"???");                
            }            

        }            
    }

    public void AddAmmo(int style,int currentAmmoAdded,int currentTotalAmmoAdded)
    {
        if(style == 0)
        {
            primaryCurrentAmmo += currentAmmoAdded;
            primaryCurrentTotalAmmo += currentTotalAmmoAdded;
            hud.UpdateWeaponAmmoUI(primaryCurrentAmmo,primaryCurrentTotalAmmo);            
            

        }
        if(style == 1)
        {
            secondprimaryCurrentAmmo += currentAmmoAdded;
            secondprimaryCurrentTotalAmmo += currentTotalAmmoAdded;
            hud.UpdateWeaponAmmoUI(secondprimaryCurrentAmmo,secondprimaryCurrentTotalAmmo); 
        }
        if(style == 2)
        {
            secondaryCurrentAmmo += currentAmmoAdded;
            secondaryCurrentTotalAmmo += currentTotalAmmoAdded;
            hud.UpdateWeaponAmmoUI(secondaryCurrentAmmo,secondaryCurrentTotalAmmo,"???"); 
        }   
    }
    private void ChackCanShoot(int style)
    {
        if(style == 0)
        {
            if(primaryCurrentAmmo <= 0)
                canShoot = false;
            else
                canShoot = true;        
        }

        if(style == 1)
        {
            if(secondprimaryCurrentAmmo <= 0)
                canShoot = false;
            else
                canShoot = true;             
        }

        if(style == 2)
        {
            if(secondaryCurrentAmmo <= 0)
                canShoot = false;
            else
                canShoot = true; 
        }    
    }
    
    private void Reload(int style)
    {
        if(canReload)
        {
            Weapon currentWeapon = inventory.GetItem(manager.currentEquippedWeapon);
            if(style == 0)
            {
                int ammoToReload_primary = inventory.GetItem(0).magazinSize - primaryCurrentAmmo;

                if(primaryCurrentTotalAmmo > 0)
                {
                    if(primaryCurrentAmmo == inventory.GetItem(0).magazinSize)
                    {
                        return;                    
                    }
                    if(primaryCurrentTotalAmmo < ammoToReload_primary)
                    {
                        AddAmmo(style,primaryCurrentTotalAmmo,0);
                        UseAmmo(style,0,primaryCurrentTotalAmmo);
                        ChackCanShoot(style);                    
                    }
                    else
                    {
                        AddAmmo(style,ammoToReload_primary,0);
                        UseAmmo(style,0,ammoToReload_primary);
                        ChackCanShoot(style);
                    }
                    anim.SetTrigger("reload");
                    manager.currrentAnim.SetTrigger("reload");
                    aud.PlayOneShot(currentWeapon.reload_sound,0.2f);
                }
            }

            if(style == 1)
            {
                int ammoToReload_secondprimary = inventory.GetItem(1).magazinSize - secondprimaryCurrentAmmo;

                if(secondprimaryCurrentTotalAmmo > 0)
                {
                    if(secondprimaryCurrentAmmo == inventory.GetItem(1).magazinSize)
                    {
                        return;
                    }
                    if(primaryCurrentTotalAmmo < ammoToReload_secondprimary)
                    {
                        AddAmmo(style,primaryCurrentTotalAmmo,0);
                        UseAmmo(style,0,primaryCurrentTotalAmmo);
                        ChackCanShoot(style);                    
                    }
                    else
                    {
                        AddAmmo(style,ammoToReload_secondprimary,0);
                        UseAmmo(style,0,ammoToReload_secondprimary);
                        ChackCanShoot(style);
                    }
                    anim.SetTrigger("reload");
                    manager.currrentAnim.SetTrigger("reload");
                    aud.PlayOneShot(currentWeapon.reload_sound,0.2f);
                }
            }

            if(style == 2)
            {
                int ammoToReload_secondary = inventory.GetItem(2).magazinSize - secondaryCurrentAmmo;

                if(secondaryCurrentAmmo == inventory.GetItem(2).magazinSize)
                {
                    return;
                }                
                AddAmmo(style,ammoToReload_secondary,0);
                UseAmmo(style,0,0);
                ChackCanShoot(style);
                anim.SetTrigger("reload");
                manager.currrentAnim.SetTrigger("reload");
                aud.PlayOneShot(currentWeapon.reload_sound,0.4f);
            }
        }

    }
}

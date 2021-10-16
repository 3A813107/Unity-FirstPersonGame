using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    private float lastShootTime=0;
    [SerializeField]private bool canShoot=true;
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
    //[SerializeField]private bool primaryMagazineIsEmpty = false;
    ///[SerializeField]private bool secondprimaryMagazineIsEmpty = false;
    //[SerializeField]private bool secondaryMagazineIsEmpty = false;

    
    private Camera cam;
    private Inventory inventory;
    private EquipmentManager manager;

    private void Start()
    {
        cam=GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        manager = GetComponent<EquipmentManager>();
    }
    private void Update()
    {

        if(Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.LeftShift))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload(manager.currentEquippedWeapon);
        }
    }

    private void RaycastShoot(Weapon currentWeapon)
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2,Screen.height / 2));

        RaycastHit hit;

        float currentWeaponRange = currentWeapon.range;

        if(Physics.Raycast(ray,out hit,currentWeaponRange))
        {
            Debug.Log(hit.transform.name);
        }
        Instantiate(currentWeapon.muzzleFlashParticles,manager.currentWeaponFlash);
    }

    private void Shoot()
    {
        ChackCanShoot(manager.currentEquippedWeapon);

        if(canShoot)
        {
            Weapon currentWeapon = inventory.GetItem(manager.currentEquippedWeapon);

            if(Time.time > lastShootTime + currentWeapon.fireRate)
            {
                Debug.Log("shoot");
                lastShootTime = Time.time;
                UseAmmo((int)currentWeapon.weaponStyle,1,0);
                RaycastShoot(currentWeapon);
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

    private void UseAmmo(int style,int currentAmmoUsed,int currentTotalAmmoUsed)

    {
        if(style == 0)
        {
            if(primaryCurrentAmmo <= 0)
            {
                //primaryMagazineIsEmpty =true;
                ChackCanShoot(manager.currentEquippedWeapon);
            }

            else
            {
                primaryCurrentAmmo -= currentAmmoUsed;
                primaryCurrentTotalAmmo -= currentTotalAmmoUsed;
            }   

        }
        if(style == 1)
        {
            if(secondprimaryCurrentAmmo <= 0)
            {
                //secondprimaryMagazineIsEmpty =true;
                ChackCanShoot(manager.currentEquippedWeapon);
            }
            else
            {         
                secondprimaryCurrentAmmo -= currentAmmoUsed;
                secondprimaryCurrentTotalAmmo -= currentTotalAmmoUsed;
            }
        }
        if(style == 2)
        {
            if(secondaryCurrentAmmo <= 0)
            {
                //secondaryMagazineIsEmpty =true;
                ChackCanShoot(manager.currentEquippedWeapon);
            }               
            else
            {
                secondaryCurrentAmmo -= currentAmmoUsed;
                secondaryCurrentTotalAmmo -= currentTotalAmmoUsed;
            }            

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

        if(style == 0)
        {
            int ammoToReload_primary = inventory.GetItem(0).magazinSize - primaryCurrentAmmo;

            if(primaryCurrentTotalAmmo >= ammoToReload_primary)
            {
                if(primaryCurrentAmmo == inventory.GetItem(0).magazinSize)
                    Debug.Log("彈藥是滿的");

                primaryCurrentAmmo += ammoToReload_primary;
                primaryCurrentTotalAmmo -= ammoToReload_primary;
                ChackCanShoot(style);
            }
        }

        if(style == 1)
        {
            int ammoToReload_secondprimary = inventory.GetItem(1).magazinSize - secondprimaryCurrentAmmo;

            if(secondprimaryCurrentTotalAmmo >= ammoToReload_secondprimary)
            {
                if(secondprimaryCurrentAmmo == inventory.GetItem(1).magazinSize)
                    Debug.Log("彈藥是滿的");

                secondprimaryCurrentAmmo += ammoToReload_secondprimary;
                secondprimaryCurrentTotalAmmo -= ammoToReload_secondprimary;
                ChackCanShoot(style);
            }
        }

        if(style == 2)
        {
            int ammoToReload_secondary = inventory.GetItem(2).magazinSize - secondaryCurrentAmmo;

            if(secondaryCurrentTotalAmmo >= ammoToReload_secondary)
            {
                if(secondaryCurrentAmmo == inventory.GetItem(2).magazinSize)
                    Debug.Log("彈藥是滿的");

                secondaryCurrentAmmo += ammoToReload_secondary;
                secondaryCurrentTotalAmmo -= ammoToReload_secondary;
                ChackCanShoot(style);
            }
        }
    }
}

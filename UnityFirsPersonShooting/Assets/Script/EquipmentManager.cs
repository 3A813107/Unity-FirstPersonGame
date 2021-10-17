using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EquipmentManager : MonoBehaviour
{
    public int currentEquippedWeapon = 0;
    public GameObject currentWeaponObject = null;
    public Transform currentWeaponFlash = null;
    public Transform WeaponHolderR = null;
    private Animator anim;
    private Inventory inventory;
    private PlayerHUD hud;

    private WeaponShooting shooting;
    private GunRecoil recoil;

    public Weapon defaultWeapon = null;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();        
        inventory = GetComponent<Inventory>();
        hud = GetComponent<PlayerHUD>();
        shooting = GetComponent<WeaponShooting>();
        recoil = GetComponentInChildren<GunRecoil>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && currentEquippedWeapon !=0 && inventory.GetItem(0) != null)
        {
            UnEquipWeapon();
            EquipWeapon(inventory.GetItem(0));
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && currentEquippedWeapon !=1 && inventory.GetItem(1) != null)
        {          
            UnEquipWeapon();
            EquipWeapon(inventory.GetItem(1));
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && currentEquippedWeapon !=2&& inventory.GetItem(2) != null)
        {
            UnEquipWeapon();
            EquipWeapon(inventory.GetItem(2));
            shooting.AddAmmo((int)defaultWeapon.weaponStyle,0,0);
        }

    }


    public void EquipWeapon(Weapon weapon)
    {
        currentEquippedWeapon = (int)weapon.weaponStyle;
        anim.SetInteger("weaponType",(int)weapon.weaponType);
        recoil.UpdateRecoiImfo(weapon.recoilX,weapon.recoilY,weapon.recoilZ,weapon.snappiness,weapon.returnSpeed);
        hud.UpdateWeaponUI(weapon);
        shooting.AddAmmo((int)weapon.weaponStyle,0,0);
    }
    public void EquipDefaltWeapon()
    {
        currentEquippedWeapon = (int)defaultWeapon.weaponStyle;
        anim.SetInteger("weaponType",(int)defaultWeapon.weaponType);
        recoil.UpdateRecoiImfo(defaultWeapon.recoilX,defaultWeapon.recoilY,defaultWeapon.recoilZ,defaultWeapon.snappiness,defaultWeapon.returnSpeed);
        hud.UpdateWeaponUI(defaultWeapon);
        hud.UpdateDefaltWeapon(defaultWeapon);
    }

    private void UnEquipWeapon()
    {
        anim.SetTrigger("unequipWeapon");
    }

}

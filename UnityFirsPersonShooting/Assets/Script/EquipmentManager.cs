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

    public Weapon defaultWeapon = null;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
        hud = GetComponent<PlayerHUD>();
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
        }

    }


    public void EquipWeapon(Weapon weapon)
    {
        currentEquippedWeapon = (int)weapon.weaponStyle;
        anim.SetInteger("weaponType",(int)weapon.weaponType);
        hud.UpdateWeaponUI(weapon);
    }

    private void UnEquipWeapon()
    {
        anim.SetTrigger("unequipWeapon");
    }

}

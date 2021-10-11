using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EquipmentManager : MonoBehaviour
{
    public int currentEquippedWeapon = 0;
    public GameObject currentWeaponObject = null;
    public Transform WeaponHolderR = null;
    private Animator anim;
    private Inventory inventory;

    public Weapon defaultWeapon = null;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && currentEquippedWeapon !=0)
        {
            UnEquipWeapon();
            EquipWeapon(inventory.GetItem(0));
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && currentEquippedWeapon !=1)
        {
            UnEquipWeapon();
            EquipWeapon(inventory.GetItem(1));
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && currentEquippedWeapon !=2)
        {
            UnEquipWeapon();
            EquipWeapon(inventory.GetItem(2));
        }

    }


    public void EquipWeapon(Weapon weapon)
    {
        currentEquippedWeapon = (int)weapon.weaponStyle;
        anim.SetInteger("weaponType",(int)weapon.weaponType);
    }

    private void UnEquipWeapon()
    {
        anim.SetTrigger("unequipWeapon");
    }

}
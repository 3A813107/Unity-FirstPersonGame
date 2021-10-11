using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EquipmentManager : MonoBehaviour
{
    private int currentEquippedWeapon = 0;
    private GameObject currentWeaponObject = null;
    [SerializeField] private Transform WeaponHolderR = null;
    private Animator anim;
    private Inventory inventory;

    [SerializeField]Weapon defaultWeapon = null;

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


    private void EquipWeapon(Weapon weapon)
    {
        currentEquippedWeapon = (int)weapon.weaponStyle;
        anim.SetInteger("weaponType",(int)weapon.weaponType);
        currentWeaponObject = Instantiate(weapon.prefab,WeaponHolderR);
    }

    private void UnEquipWeapon()
    {
        anim.SetTrigger("unequipWeapon");
        Destroy(currentWeaponObject);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private Transform WeaponHolderR = null;
    private Animator anim;
    private Inventory inventory;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeaponAnimation(0,WeaponType.AR);

            EquipWeapon(inventory.GetItem(0).prefab,0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeaponAnimation(1,WeaponType.Shotgun);
            SetWeaponAnimation(1,WeaponType.Sniper);
            EquipWeapon(inventory.GetItem(1).prefab,1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeaponAnimation(2,WeaponType.Pistol);
            EquipWeapon(inventory.GetItem(2).prefab,2);
        }
    }

    private void SetWeaponAnimation(int weaponStyle,WeaponType weaponType)
    {
        Weapon weapon = inventory.GetItem(weaponStyle);
        if(weapon != null)
        {
            if(weapon.weaponType == weaponType)
            {
                anim.SetInteger("weaponType", (int)weaponType);
            }
        }
    }

    private void EquipWeapon(GameObject weaponObject,int weaponStyle)
    {
        Weapon weapon = inventory.GetItem(weaponStyle);
        if(weapon != null)
        {
            Instantiate(weaponObject,WeaponHolderR);
        }
    }
}

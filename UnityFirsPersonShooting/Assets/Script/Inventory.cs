using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]private Weapon[] weapons;
    public int grenadeNum=2;

    private WeaponShooting shooting;

    private EquipmentManager Eqmanager;

    private PlayerHUD hud;

    private void Start()
    {
        weapons =new Weapon[3];
        hud = GetComponent<PlayerHUD>();
        shooting = GetComponent<WeaponShooting>();
        Eqmanager = GetComponent<EquipmentManager>();
        defaltWeaponSetUp();
        hud.UpdateGrenadeUI(grenadeNum);
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.weaponStyle;
        if(weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        weapons[newItemIndex] = newItem;
        shooting.InitAmmo((int)newItem.weaponStyle,newItem);
    }

    public void RemoveItem(int index)
    {
        weapons[index]= null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }

    private void defaltWeaponSetUp()
    {
        AddItem(Eqmanager.defaultWeapon);
        Eqmanager.EquipDefaltWeapon();        
    }
}

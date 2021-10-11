using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]private Weapon[] weapons;
    private PlayerHUD hud;

    private EquipmentManager Eqmanager;

    private void Start()
    {
        weapons =new Weapon[3];
        Eqmanager = GetComponent<EquipmentManager>();
        hud=GetComponent<PlayerHUD>();
        defaltWeaponSetUp();
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.weaponStyle;
        if(weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        weapons[newItemIndex] = newItem;

        hud.UpdateWeaponUI(newItem);
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
        Eqmanager.EquipWeapon(GetItem(2));
    }
}

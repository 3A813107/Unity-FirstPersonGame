using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]private Weapon[] weapons;
    private PlayerHUD hud;

    private void Start()
    {
        hud=GetComponent<PlayerHUD>();
        weapons =new Weapon[3];
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
}

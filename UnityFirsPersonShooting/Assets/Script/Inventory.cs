using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]private Weapon[] weapons;

    private void Start()
    {
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
    }

    public void RemoveItem(int index)
    {
        weapons[index]= null;
    }

    public Weapon GerItem(int index)
    {
        return weapons[index];
    }
}

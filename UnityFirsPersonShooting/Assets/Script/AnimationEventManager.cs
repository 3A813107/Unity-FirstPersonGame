using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    private Inventory inventory;

    private EquipmentManager manager;

    private void Start()
    {
        inventory = GetComponentInParent<Inventory>();
        manager = GetComponentInParent<EquipmentManager>();
    }
    public void DestroyWeapon()
    {
        Destroy(manager.currentWeaponObject);
    }
    public void InstantiateWeapon()
    {
       manager.currentWeaponObject = Instantiate(inventory.GetItem(manager.currentEquippedWeapon).prefab,manager.WeaponHolderR);
    }
}

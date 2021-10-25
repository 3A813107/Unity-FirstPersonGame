using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    private Inventory inventory;

    private WeaponShooting shooting;

    private EquipmentManager manager;

    private void Start()
    {
        inventory = GetComponentInParent<Inventory>();
        manager = GetComponentInParent<EquipmentManager>();
        shooting = GetComponentInParent<WeaponShooting>();
    }

    public void canShoot_SwapSwitch()
    {
        shooting.canShoot_swap=!shooting.canShoot_swap;
    }
    public void DestroyWeapon()
    {
        Destroy(manager.currentWeaponObject);
    }
    public void InstantiateWeapon()
    {
       manager.currentWeaponObject = Instantiate(inventory.GetItem(manager.currentEquippedWeapon).prefab,manager.WeaponHolderR);
       manager.currentWeaponFlash = manager.currentWeaponObject.transform.GetChild(0);
       manager.currrentAnim = manager.currentWeaponObject.GetComponent<Animator>();
    }

    public void SwitchReloading()
    {
        shooting.canReload = !shooting.canReload;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private ShieldBar shieldBar;
    [SerializeField] private WeaponUI weaponUI;

    public void UpdateHealth(int currentHealth,int maxHealth)
    {
        healthBar.SetValue(currentHealth,maxHealth);
    }
    public void UpdateShield(int currentShield,int maxShield)
    {
        shieldBar.SetValue(currentShield,maxShield);
    }

    public void UpdateWeaponUI(Weapon newWeapon)
    {
        weaponUI.UpdateInfo(newWeapon.icon,newWeapon.Name);
    }

    public void UpdateWeaponAmmoUI(int currentAmmo,int currentTotalAmmo)
    {
        weaponUI.UpdateAmmoUI(currentAmmo,currentTotalAmmo);
    }
    public void UpdateWeaponAmmoUI(int currentAmmo,int currentTotalAmmo,string text)//無限彈藥武器 多載
    {
        weaponUI.UpdateAmmoUI(currentAmmo,currentTotalAmmo,text);
    }

    public void UpdateDefaltWeapon(Weapon defaltweapon)
    {
        weaponUI.UpdateDefaltWeaponUI(defaltweapon.icon,defaltweapon.name,defaltweapon.magazinSize,defaltweapon.TotalAmmo);
    }
}

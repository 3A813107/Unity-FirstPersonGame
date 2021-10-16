using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField]private Image icon;
    [SerializeField]private Text magazineSizeText;
    [SerializeField]private Text totalAmmoText;
    [SerializeField]private Text weaponNameText;

    public void UpdateInfo(Sprite weaponIcon,string weaponName)
    {
        icon.sprite = weaponIcon;
        weaponNameText.text=weaponName;
    }

    public void UpdateAmmoUI(int magazineSize,int totalAmmo)
    {
        totalAmmoText.fontSize=40;
        magazineSizeText.text=magazineSize.ToString();
        totalAmmoText.text=totalAmmo.ToString();        
    }
    public void UpdateAmmoUI(int magazineSize,int totalAmmo,string text)   //無限彈藥武器 多載
    {
        totalAmmoText.fontSize=80;
        magazineSizeText.text=magazineSize.ToString();
        totalAmmoText.text=text.ToString();        
    }
    public void UpdateDefaltWeaponUI(Sprite weaponIcon,string weaponName,int magazineSize,int totalAmmo)
    {
        icon.sprite = weaponIcon;
        weaponNameText.text=weaponName;
        magazineSizeText.text=magazineSize.ToString();
        totalAmmoText.fontSize=80;
        totalAmmoText.text=("∞").ToString();
    }

}

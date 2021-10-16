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

    public void UpdateInfo(Sprite weaponIcon,int magazineSize,int TotalAmmo,string weaponName)
    {
        icon.sprite = weaponIcon;
        weaponNameText.text=weaponName;
        magazineSizeText.text=magazineSize.ToString();
        totalAmmoText.text=TotalAmmo.ToString();
    }

}

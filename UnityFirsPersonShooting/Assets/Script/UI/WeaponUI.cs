using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField]private Image icon;
    [SerializeField]private Text magazineSizeText;
    [SerializeField]private Text magazineCountText;
    [SerializeField]private Text weaponNameText;

    public void UpdateInfo(Sprite weaponIcon,int magazineSize,int magazineCount,string weaponName)
    {
        icon.sprite = weaponIcon;
        weaponNameText.text=weaponName;
        magazineSizeText.text=magazineSize.ToString();
        int magazineCountAmount = magazineSize * magazineCount;
        magazineCountText.text=magazineCountAmount.ToString();
    }

}

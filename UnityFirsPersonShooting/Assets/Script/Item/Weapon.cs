using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon" , menuName = "Items/Weapon")]
public class Weapon : Item
{
    public GameObject prefab;
    public GameObject muzzleFlashParticles;
    public int magazinSize;
    public int magazinCount;

    public float fireRate;
    public float range;
    public WeaponType weaponType;
    public WeaponStyle weaponStyle;
}

public enum WeaponType{Pistol,AR,Shotgun,Sniper,Melee}
public enum WeaponStyle{Primary,SecondPrimary,Secondary};
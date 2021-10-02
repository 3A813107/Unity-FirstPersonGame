using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon" , menuName = "Items/Weapon")]
public class Weapon : Item
{
    public GameObject prefab;
    public int magazinSize;
    public int magazinCount;
    public float range;
    public WeaponType weaponType;
}

public enum WeaponType{Melee,Postol,AR,Shotgun,Sniper}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon" , menuName = "Items/Weapon")]
public class Weapon : Item
{
    public GameObject prefab;
    public GameObject muzzleFlashParticles;
    public GameObject impactEffect;
    public int magazinSize;
    public int TotalAmmo;    
    public float fireRate;
    public float range;
    public int damage;
    public WeaponType weaponType;
    public WeaponStyle weaponStyle;
    public AudioClip shot_sound;
    public AudioClip reload_sound;


    [Header("後座力")]
    [Tooltip("垂直後座力")]
    public float recoilX;
    [Tooltip("平行後座力")]
    public  float recoilY;
    [Tooltip("旋轉後座力")]
    public  float recoilZ;
    [Tooltip("晃動程度")]    
    public  float snappiness;
    [Tooltip("後座力回復速度")]
    public  float returnSpeed;

}

public enum WeaponType{Pistol,AR,Shotgun,Sniper,Melee};
public enum WeaponStyle{Primary,SecondPrimary,Secondary};
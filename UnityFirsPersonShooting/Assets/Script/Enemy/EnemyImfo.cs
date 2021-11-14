using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy" , menuName = "Enemy")]

public class EnemyImfo : ScriptableObject
{
    public string Name;
    public int Hp;
    public int Shiled;
    public int Damage;
    public float AttackSpeed;
}

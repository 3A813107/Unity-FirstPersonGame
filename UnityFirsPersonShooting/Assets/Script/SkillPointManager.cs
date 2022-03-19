using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointManager : MonoBehaviour
{
    public int TotalCost;
    [SerializeField]private SkillPoint attackPoint;
    [SerializeField]private SkillPoint Health;
    [SerializeField]private SkillPoint Shiled;
    [SerializeField]private StoreUI storeUI;
    [SerializeField] private Transform player;
    public PlayerStats playerStats;
    public Text totalText;

    void Start()
    {
        storeUI=GetComponentInParent<StoreUI>();
        player=PlayerMovement.instance;
        playerStats=player.GetComponent<PlayerStats>();
        
    }
    public void UpdateCost(int cost)
    {
        TotalCost += cost;
        totalText.text = TotalCost.ToString();
    }

    public void Buy()
    {
        storeUI.playerStats.GetMoney(-TotalCost);
        TotalCost = 0;
        UpdateCost(0);
        ////////////////////////////   
        Health.SetLimilt();
        playerStats.maxHealth+=Health.GetPoint()*20;//HP
        playerStats.CheackMaxHealth(Health.GetPoint()*20);
        ////////////////////////////
        Shiled.SetLimilt();
        playerStats.MaxShield+=Shiled.GetPoint()*20;//護盾
        //////////////////////////////
        attackPoint.SetLimilt();
    }
}

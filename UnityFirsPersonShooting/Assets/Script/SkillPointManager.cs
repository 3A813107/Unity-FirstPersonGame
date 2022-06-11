using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointManager : MonoBehaviour
{
    public int TotalCost;
    [SerializeField]private SkillPoint ammoPoint;

    [SerializeField]private SkillPoint GrenadePoint;
    [SerializeField]private SkillPoint Health;
    [SerializeField]private SkillPoint Shiled;
    [SerializeField]private StoreUI storeUI;
    [SerializeField] private Transform player;
    public PlayerStats playerStats;
    public Inventory inventory;
    public WeaponShooting shooting;
    public PlayerHUD playerHUD;
    public Text totalText;

    void Start()
    {
        storeUI=GetComponentInParent<StoreUI>();
        player=PlayerMovement.instance;
        playerStats=player.GetComponent<PlayerStats>();
        inventory=player.GetComponent<Inventory>();
        shooting=player.GetComponent<WeaponShooting>();
        playerHUD=player.GetComponent<PlayerHUD>();
        
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
        if(inventory.GetItem(0)!=null && ammoPoint.point==1)
        {
            shooting.InitAmmo(0,inventory.GetItem(0));//彈藥
            ammoPoint.point = 0;
            ammoPoint.PointText.text=(ammoPoint.point).ToString();
        }
        //////////////////////////////
        inventory.grenadeNum+=GrenadePoint.point;//爆彈
        playerHUD.UpdateGrenadeUI(inventory.grenadeNum);
        GrenadePoint.point=0;
        GrenadePoint.PointText.text=(GrenadePoint.point).ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointManager : MonoBehaviour
{
    public int TotalCost;
    [SerializeField]private SkillPoint attackPoint;
    [SerializeField]private SkillPoint Health;
    [SerializeField]private StoreUI storeUI;
    public Text totalText;

    void Start()
    {
        storeUI=GetComponentInParent<StoreUI>();
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
        Health.SetLimilt();
        attackPoint.SetLimilt();
    }
}

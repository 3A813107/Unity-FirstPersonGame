using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPoint : MonoBehaviour
{
    public int point=0;
    public bool isItem;
    [SerializeField]private SkillPointManager spManager;
    [SerializeField]private int price;
    [SerializeField]public Text PointText;
    [SerializeField]private int LimiltPoint=0;
    [SerializeField]private int finalPoint=0; 
    public void addPoint()
    {
        if(isItem)
        {
            if(GameManager.instance.PlayerMoney - spManager.TotalCost >= price)
            {
                if(point < 1)
                {
                    spManager.UpdateCost(price);    
                    point++;                
                }                   
                PointText.text=point.ToString();
            }            
        }
        else
        {
            if(GameManager.instance.PlayerMoney - spManager.TotalCost >= price)
            {
                spManager.UpdateCost(price);
                point++;
                PointText.text=point.ToString();
            }
        }


    }

    public void reducePoint()
    {
        if(point > LimiltPoint)
        {
            spManager.UpdateCost(-price);
            point--;
            PointText.text=point.ToString();
        }

    }

    public  void  SetLimilt()
    {
        if(!isItem)
        {
            finalPoint = point-LimiltPoint;
            LimiltPoint = point;
        }

    }

    public int GetPoint()
    {
        return finalPoint;
    }

}

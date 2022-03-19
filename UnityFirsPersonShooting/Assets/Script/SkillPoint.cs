using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPoint : MonoBehaviour
{
    private int point=0;

    [SerializeField]private SkillPointManager spManager;
    [SerializeField]private int price;
    [SerializeField]private Text PointText;
    [SerializeField]private int LimiltPoint=0;
    [SerializeField]private int finalPoint=0; 
    public void addPoint()
    {
        if(GameManager.instance.PlayerMoney - spManager.TotalCost >= price)
        {
            spManager.UpdateCost(price);
            point++;
            PointText.text=point.ToString();
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
        finalPoint = point-LimiltPoint;
        LimiltPoint = point;
    }

    public int GetPoint()
    {
        return finalPoint;
    }

}

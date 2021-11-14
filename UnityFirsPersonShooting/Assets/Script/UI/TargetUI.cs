using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUI : MonoBehaviour
{
    [SerializeField]private Text TargetName;
    [SerializeField]private Image Hpfill;
    [SerializeField]private Image Shiledfill;
    private int baseValue;
    private int maxValue;
    public void UpdateTargetName(string Name)
    {
        TargetName.text = (Name).ToString(); 
    }
    public void UpdateTargetHp(int _maxValue,int _baseValue)
    {
        Hpfill.fillAmount=CalculatFillAmount(_maxValue,_baseValue);
    }
    public void UpdateTargetShiled(int _maxValue,int _baseValue)
    {
        Shiledfill.fillAmount=CalculatFillAmount(_maxValue,_baseValue);
    }
    private float CalculatFillAmount(int maxValue,int baseValue)
    {
        float fillAmount = (float)baseValue / (float)maxValue;
        return fillAmount;
    }
}

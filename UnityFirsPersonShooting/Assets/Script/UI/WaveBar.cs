using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour
{
    private int baseValue;
    private int maxValue;

    [SerializeField]private Image fill;

    public void SetValue(int _baseValue,int _maxValue)
    {
        baseValue=_baseValue;
        maxValue=_maxValue;
        CalculatFillAmount();
    }

    private void CalculatFillAmount()
    {
        float fillAmount = (float)baseValue / (float)maxValue;
        fill.fillAmount=fillAmount;
    }
}

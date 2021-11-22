using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text MoneyNum;

    public void UpdateMoney(int num)
    {
        MoneyNum.text = num.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeUI : MonoBehaviour
{
    public Text GrenadeNum;

    public void UpdateGrenade(int num)
    {
        GrenadeNum.text = num.ToString();
    }
}

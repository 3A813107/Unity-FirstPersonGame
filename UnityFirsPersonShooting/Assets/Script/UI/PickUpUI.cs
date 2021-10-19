using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpUI : MonoBehaviour
{
    [SerializeField] private Text PickUpItemNameText;

    public void UpdateImfo(string itemName)
    {
        PickUpItemNameText.text = (itemName).ToString(); 
    }
}

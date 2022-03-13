using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUI : MonoBehaviour
{
    [SerializeField]private GameObject Store;
    [SerializeField] private Transform player;
    public PlayerStats playerStats;

    private bool isTab = false;
    void Start()
    {
        player=PlayerMovement.instance;
        playerStats=player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(isTab == false)
            {
                isTab=!isTab;
                playerStats.GetMoney(0);
                Store.SetActive(isTab);
                Cursor.visible=true;
                Cursor.lockState=CursorLockMode.None;
                GameManager.isPause = true;
            }
            else if(isTab == true)
            {
                isTab=!isTab;
                Store.SetActive(isTab);
                Cursor.visible=false;
                GameManager.isPause = false;
            }

        }
    }
}

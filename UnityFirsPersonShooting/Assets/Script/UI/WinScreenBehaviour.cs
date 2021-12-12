using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenBehaviour : MonoBehaviour
{
    public GameObject HUD;
    public GameObject WinScreen;

    public void Win()
    {
        GameManager.isPause = true;
        Cursor.lockState = CursorLockMode.None;
        HUD.SetActive(false);
        WinScreen.SetActive(true);
        //Time.timeScale = 0f;
    }
}

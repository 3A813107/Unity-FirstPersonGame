using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenBehaviour : MonoBehaviour
{
    public GameObject HUD;

    public MoneyUI moneyUI;
    public GameObject LosScreen;

    public void Lose()
    {
        GameManager.isPause = true;
        Cursor.lockState = CursorLockMode.None;
        HUD.SetActive(false);
        LosScreen.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void LoadLevel_01()
    {
        GameManager.isPause = false;
        GameManager.instance.isboomTaking=false;
        GameManager.instance.PlayerMoney = 0;
        GameManager.instance.WaveKillNum = 0;
        GameManager.instance.currentBoomPos=GameManager.instance.BoomPos;
        SceneManager.LoadScene("Level_01");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

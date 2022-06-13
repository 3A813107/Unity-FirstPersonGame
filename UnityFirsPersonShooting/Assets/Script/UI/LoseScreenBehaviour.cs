using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenBehaviour : MonoBehaviour
{
    public GameObject HUD;

    public MoneyUI moneyUI;
    public GameObject LosScreen;

    public AudioClip lose_snd;
    public AudioSource aud;

    public void Lose()
    {
        GameManager.isPause = true;
        GameManager.instance.Lose = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        HUD.SetActive(false);
        LosScreen.SetActive(true);
        aud.clip=lose_snd;
        aud.volume=0.2f;
        aud.PlayOneShot(lose_snd);
        aud.loop=false;
        //Time.timeScale = 0f;
    }

    public void LoadLevel_01()
    {
        GameManager.isPause = false;
        GameManager.instance.Lose = false;
        GameManager.instance.isboomTaking=false;
        GameManager.instance.PlayerMoney = 0;
        GameManager.instance.WaveKillNum = 0;
        GameManager.instance.currentBoomPos=GameManager.instance.BoomPos;
        SceneManager.LoadScene("Level_01");
    }
    public void LoadLevel_02()
    {
        GameManager.isPause = false;
        GameManager.instance.Lose = false;
        GameManager.instance.isboomTaking=false;
        GameManager.instance.PlayerMoney = 0;
        GameManager.instance.WaveKillNum = 0;
        GameManager.instance.currentBoomPos=GameManager.instance.BoomPos;
        SceneManager.LoadScene("Level_02");
    }
    
    public void LoadLevel_03()
    {
        GameManager.isPause = false;
        GameManager.instance.Lose = false;
        GameManager.instance.isboomTaking=false;
        GameManager.instance.PlayerMoney = 0;
        GameManager.instance.WaveKillNum = 0;
        GameManager.instance.currentBoomPos=GameManager.instance.BoomPos;
        SceneManager.LoadScene("Level_03");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

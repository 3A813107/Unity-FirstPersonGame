using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class WinScreenBehaviour : MonoBehaviour
{
    public GameObject HUD;
    public GameObject WinScreen;
    public AudioClip win_snd;
    public AudioSource aud;

    public void Win()
    {
        GameManager.isPause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        HUD.SetActive(false);
        WinScreen.SetActive(true);
        aud.clip=win_snd;
        aud.volume=0.2f;
        aud.PlayOneShot(win_snd);
        aud.loop=false;
        //Time.timeScale = 0f;
    }

    public void Load_level_02()
    {
        SceneManager.LoadScene("Intro_02");
        GameManager.isPause = false;
    }
    public void Load_level_03()
    {
        SceneManager.LoadScene("Intro_03");
        GameManager.isPause = false;
    }
    public void Load_level_04()
    {
        SceneManager.LoadScene("Intro_04");
        GameManager.isPause = false;
    }
    public void Load_level_Ending()
    {
        SceneManager.LoadScene("Ending");
        GameManager.isPause = false;
    }
}
